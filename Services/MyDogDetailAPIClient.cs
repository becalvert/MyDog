using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyDog.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyDog.Services
{
    public class MyDogDetailAPIClient
    {

        public HttpClient Client { get; set; }

        public MyDogDetailAPIClient(HttpClient client)
        {

            client.BaseAddress = new System.Uri("https://localhost:44371");

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;

        }

        public async Task<IEnumerable<MyDogDetail>> GetDogList()

        {
            return await Client.GetFromJsonAsync<IEnumerable<MyDogDetail>>("api/MyDogDetails");
        }

        public async Task<MyDogDetail> GetDogDetail(int Id)

        {
            
            return await Client.GetFromJsonAsync<MyDogDetail>("api/MyDogDetails/" + Id);
        }

        public async Task CreateDogDetail(MyDogDetail dogDetail)

        {
            await Client.PostAsJsonAsync<MyDogDetail>("api/MyDogDetails", dogDetail);
            return;
        }

        public async Task UpdateDogDetail(int Id, MyDogDetail DogDetail)

        {
            var MyDogID = Id.ToString();
            await Client.PutAsJsonAsync("api/MyDogDetails/" + MyDogID, DogDetail);
            return;

        }

        public async Task DeleteDogDetail(int Id)

        {
            var MyDogID = Id.ToString();
            await Client.DeleteAsync("api/MyDogDetails/" + MyDogID);
            return;
        }


    }
}

