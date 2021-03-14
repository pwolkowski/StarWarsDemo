using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsDemo.Dal;
using StarWarsDemo.SWApiServices;
using StarWarsDemo.SWApiServices.Dto;

namespace Logic
{
    public class FilmsService : IFilmsService
    {
        private readonly ISWApiService _swApiService;
        private readonly IRatingRepository _ratingRepository;

        public FilmsService(ISWApiService swApiService,
            IRatingRepository ratingRepository)
        {
            _swApiService = swApiService;
            _ratingRepository = ratingRepository;
        }

        public async Task<List<Film>> GetFilms()
        {
            return await _swApiService.GetFilms();
        }

        public async Task<FilmDetails> GetFIlmDetails(int filmId)
        {
            var filmDetails = await _swApiService.GetFilmDetails(filmId);
            filmDetails.Ratings = _ratingRepository.GetRatings(filmId).ToList();
            return filmDetails;
        }

        public async Task AddNewRating(int filmId, int rating)
        {
            await _ratingRepository.AddRating(filmId, rating);
        }
    }
}
