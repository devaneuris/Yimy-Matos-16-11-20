using AutoMapper;
using BertoniLibrary.Models;
using BertoniLibrary.Contracts;
using Bertoni.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceType _serviceType;
        private readonly IMapper _mapper;

        public HomeController(IServiceType serviceType, IMapper mapper)
        {
            _serviceType = serviceType;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _serviceType.Albums();

            var album = new AlbumsViewModel() 
            {
                AlbumId = albums.ElementAt(0).Id,
                Albums = _mapper.Map<List<SelectListItem>>(albums),
            };
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AlbumsViewModel model) {
            if (ModelState.IsValid) {
                return RedirectToAction("Photos", new { albumId = model.AlbumId });
            }

            return View(model);
        }

        [Route("Album/{albumId}/Photos")]
        public async Task<IActionResult> Photos(int albumId) 
        {
            var photos = await _serviceType.Photos(albumId);
            var _photos = _mapper.Map<List<Photo>>(photos);
            return View(_photos);
        }

        [Route("Photos/{photoId}/Comments")]
        public async Task<IActionResult> Comments(int photoId) 
        {
            var comments = await _serviceType.Comments(photoId);
            var _comments = _mapper.Map<List<Comment>>(comments);

            return PartialView("_PhotoComments", _comments);
        }
    }
}
