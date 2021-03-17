using Microsoft.AspNetCore.Mvc;
using RESTFulWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public class PhotoController : Controller
    {
        private IAlbumRepository albumRepository;
        private IPhotoRepository photoRepository;
        public PhotoController(IAlbumRepository albumRepository ,IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
        }
        public async Task<IActionResult> Index(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return View(new List<Photo>());
            }
            else
            {
                List<Album> albums = await albumRepository.GetAlbumByUserId(userId);
                List<int> albumIds = albums.Select(x => x.id).ToList();
                List<Photo> photos = await photoRepository.GetPhotoByAlbumIds(albumIds);
                return View(photos);

            }
        }
    }
}
