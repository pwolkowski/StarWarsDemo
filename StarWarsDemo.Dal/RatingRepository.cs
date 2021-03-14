using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsDemo.Dal.Dbo;
using StarWarsDemo.Dal.Migrations;

namespace StarWarsDemo.Dal
{
    public class RatingRepository : IRatingRepository
    {
        private readonly StarWarsDemoWebContext _dbContext;

        public RatingRepository(StarWarsDemoWebContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<int> GetRatings(int filmId)
        {
            return _dbContext.FirmRating.Where(w => w.FilmId == filmId).Select(s => s.Rating);
        }

        public async Task AddRating(int filmId, int rating)
        {
            await _dbContext.FirmRating.AddAsync(
                new FilmRating()
                {
                    Rating = rating,
                    FilmId = filmId
                });
            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IRatingRepository
    {
        Task AddRating(int filmId, int rating);
        IEnumerable<int> GetRatings(int filmId);
    }
}
