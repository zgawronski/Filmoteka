using Microsoft.EntityFrameworkCore;


namespace FilmotekaData
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Actor> Actors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Category>().HasData(GetCategory());
             modelBuilder.Entity<Year>().HasData(GetYear());
             modelBuilder.Entity<Film>().HasData(GetFilm());
             modelBuilder.Entity<Actor>().HasData(GetActor());
             //modelBuilder.Entity<Film>().HasMany(a => a.Actors).WithOne(f => f.Film);
             base.OnModelCreating(modelBuilder);
        }
        private static Film[] GetFilm()
        {
            return new Film[]
            {
                new Film {Id = 1, Title = "Titanic", CategoryId = 1, YearId = 1},
                new Film {Id = 2, Title = "Poranek Kojota", CategoryId = 2, YearId = 5}
            };
        }
        private static Actor[] GetActor()
        {
            return new Actor[]
            {
                new Actor {Id = 1, ActorName = "Kate Winslet", FilmId = 1},
                new Actor {Id = 2, ActorName = "Maciej Stuhr", FilmId = 2}
            };
        }

        private static Year[] GetYear()
        {
            return new Year[]
            {
                new Year {Id = 1, YearProduction = 1997},
                new Year {Id = 2, YearProduction = 1998},
                new Year {Id = 3, YearProduction = 1999},
                new Year {Id = 4, YearProduction = 2000},
                new Year {Id = 5, YearProduction = 2001},
                new Year {Id = 6, YearProduction = 2002},
                new Year {Id = 7, YearProduction = 2003},
                new Year {Id = 8, YearProduction = 2004},
                new Year {Id = 9, YearProduction = 2005},
                new Year {Id = 10, YearProduction = 2006},
                new Year {Id = 11, YearProduction = 2007},
                new Year {Id = 12, YearProduction = 2008},
            };
        }
        private static Category[] GetCategory()
        {
            return new Category[]
            {
                new Category {Id = 1, Genre = "Romance"},
                new Category {Id = 2, Genre = "Comedy"},
                new Category {Id = 3, Genre = "Drama"},
                new Category {Id = 4, Genre = "Sci-Fi"}
            };
        }
    }
}
