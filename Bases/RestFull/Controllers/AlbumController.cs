using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestFull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestFull.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string _domain = "https://jsonplaceholder.typicode.com/";

        public AlbumController(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                HttpClient httpClient = _client.CreateClient();
                string userToString = await httpClient.GetStringAsync(_domain + "albums?" + "userId=" + userId);
                List<Album> listAlbums = JsonConvert.DeserializeObject<List<Album>>(userToString);

                List<Photo> photos = new List<Photo>();
                foreach (Album album in listAlbums)
                {
                    string id = Convert.ToString(album.id);
                    string commentToString = await httpClient.GetStringAsync(_domain + "photos?" + "albumId=" + id);
                    List<Photo> photoToJson = JsonConvert.DeserializeObject<List<Photo>>(commentToString);
                    foreach (Photo photo in photoToJson)
                    {
                        photos.Add(photo);
                    }
                }
                return View(photos);

            }
        }
    }
}
