using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using StarWarsDemo.Web.VM;

namespace StarWarsDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmsService _filmsService;

        public HomeController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _filmsService.GetFilms();
            
            return View(new FilmListVm()
            {
                Films = films
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
