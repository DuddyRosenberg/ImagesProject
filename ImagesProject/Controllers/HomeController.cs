using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ImagesProject.Data;
using ImagesProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ImagesProject.Controllers
{
    public class HomeController : Controller
    {
        private ImagesRepository _repository;

        public HomeController(IConfiguration configuration)
        {
            _repository = new ImagesRepository(configuration.GetConnectionString("ConnectionString"));
        }
        public IActionResult Index()
        {
            return View(_repository.GetImages());
        }
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            _repository.AddImage(image);
            return Redirect("/");
        }
        public IActionResult Image(int id)
        {
            return View(new ImageViewModel
            {
                Image = _repository.GetImage(id),
                LikedImage = Request.Cookies[$"LikedImage{id}"] == "Liked"
            });
        }
        [HttpPost]
        public IActionResult LikeImage(int id)
        {
            Response.Cookies.Append($"LikedImage{id}", "Liked");
            _repository.LikeImage(id);
            return Json(new { Success = true });
        }
        public IActionResult GetLikes(int id)
        {
            return Json(new { Likes = _repository.GetLikes(id) });
        }
    }
}
