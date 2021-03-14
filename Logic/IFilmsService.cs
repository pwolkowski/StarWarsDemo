using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDemo.SWApiServices.Dto;

namespace Logic
{
    public interface IFilmsService
    {
        Task AddNewRating(int filmId, int rating);
        Task<FilmDetails> GetFIlmDetails(int filmId);
        Task<List<Film>> GetFilms();
    }
}
