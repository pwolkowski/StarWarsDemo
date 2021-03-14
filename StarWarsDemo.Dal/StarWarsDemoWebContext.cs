using Microsoft.EntityFrameworkCore;

namespace StarWarsDemo.Dal
{
    public class StarWarsDemoWebContext : DbContext
    {
        public StarWarsDemoWebContext (DbContextOptions<StarWarsDemoWebContext> options)
            : base(options)
        {
        }

        public DbSet<Dbo.FilmRating> FirmRating { get; set; }
    }
}
