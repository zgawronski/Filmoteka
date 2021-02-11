using Microsoft.EntityFrameworkCore;

namespace FilmotekaData
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=films.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
