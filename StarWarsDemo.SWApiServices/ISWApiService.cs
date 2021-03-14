using StarWarsDemo.SWApiServices.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDemo.SWApiServices
{
    public interface ISWApiService
    {
        Task<FilmDetails> GetFilmDetails(int filmId);
        Task<List<Film>> GetFilms();
    }
}