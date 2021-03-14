using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Logic;
using StarWarsDemo.Web.Validators;
using StarWarsDemo.Web.VM;

namespace StarWarsDemo.Web.Controllers
{
    public class FilmDetailsController : Controller
    {
        private readonly IFilmsService _filmsService;

        public FilmDetailsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = FilmDetailsVm.Map(await _filmsService.GetFIlmDetails(id));
            return View(result);
        }

        
        public async Task<IActionResult> AddRating()
        {
            var newRatingValidator = new NewRatingValidator();
            var id = int.Parse(Request.Form["id"]);
            var validateResult = await newRatingValidator.ValidateAsync(Request.Form["newRating"]);
            var result = FilmDetailsVm.Map(await _filmsService.GetFIlmDetails(id));
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    result.NewRatingErrors.Add(error.ErrorMessage);
                }
                return View("Details", result);
            }
            await _filmsService.AddNewRating(id, int.Parse(Request.Form["newRating"]));
            result.Ratings.Add(int.Parse(Request.Form["newRating"]));
            return View("Details", result);
        }
    }
}
