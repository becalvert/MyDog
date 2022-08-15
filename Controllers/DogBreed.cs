using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDog.Controllers
{
    public class DogBreed : Controller
    {
        // GET: DogBreed
        public ActionResult Index()
        {
            return View();
        }

        // GET: DogBreed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DogBreed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogBreed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogBreed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DogBreed/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogBreed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogBreed/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
