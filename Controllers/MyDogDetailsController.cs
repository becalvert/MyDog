using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDog.Data;
using MyDog.Services;

namespace MyDog.Controllers
{
    public class MyDogDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly MyDogDetailAPIClient _mydogdetailApiClient;


        public MyDogDetailsController(ApplicationDbContext context, MyDogDetailAPIClient mydogdetailApiClient)
        {
            _context = context;
            _mydogdetailApiClient = mydogdetailApiClient;
        
        }

        // GET: MyDogDetails
        public async Task<IActionResult> Index()
        {
            //return _context.MyDogDetail != null ? 
            //            View(await _context.MyDogDetail.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.MyDogDetail'  is null.");
            
            var DogList = await _mydogdetailApiClient.GetDogList();
            return View(DogList);

        }



        // GET: MyDogDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyDogDetail == null)
            {
                return NotFound();
            }

            int intID = id.Value;
            var myDogDetail = await _mydogdetailApiClient.GetDogDetail(intID);

            if (myDogDetail == null)
            {
                return NotFound();
            }

            return View(myDogDetail);
        }

        // GET: MyDogDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyDogDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,DateOfBirth,PetWeight,WeightUnit,PetBreed")] MyDogDetail myDogDetail)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(myDogDetail);
                await _mydogdetailApiClient.CreateDogDetail(myDogDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(myDogDetail);
        }

        // GET: MyDogDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyDogDetail == null)
            {
                return NotFound();
            }

            int intID = id.Value;
            var myDogDetail = await _mydogdetailApiClient.GetDogDetail(intID);

            if (myDogDetail == null)
            {
                return NotFound();
            }

            return View(myDogDetail);
        }

        // POST: MyDogDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,DateOfBirth,PetWeight,WeightUnit,PetBreed")] MyDogDetail myDogDetail)
        {
            if (id != myDogDetail.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(myDogDetail);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MyDogDetailExists(myDogDetail.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}

            //return View(myDogDetail);

            await _mydogdetailApiClient.UpdateDogDetail(id, myDogDetail);
            return RedirectToAction(nameof(Index));


        }

        // GET: MyDogDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyDogDetail == null)
            {
                return NotFound();
            }

            int intID = id.Value;
            var myDogDetail = await _mydogdetailApiClient.GetDogDetail(intID);

            if (myDogDetail == null)
            {
                return NotFound();
            }

            return View(myDogDetail);
        }

        // POST: MyDogDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyDogDetail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyDogDetail'  is null.");
            }
            //var myDogDetail = await _context.MyDogDetail.FindAsync(id);

            //if (myDogDetail != null)
            //{
            //    _context.MyDogDetail.Remove(myDogDetail);
            //}

            //await _context.SaveChangesAsync();

            await _mydogdetailApiClient.DeleteDogDetail(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MyDogDetailExists(int id)
        {
          return (_context.MyDogDetail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
