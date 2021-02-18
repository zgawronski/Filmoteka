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
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=films.db");
        //    optionsBuilder.UseLazyLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //} 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(GetFilm());
            modelBuilder.Entity<Film>().HasMany(a => a.Actors).WithOne(f => f.Film);
            modelBuilder.Entity<Actor>().HasData(GetActor());
            modelBuilder.Entity<Year>().HasData(GetYear());
            modelBuilder.Entity<Category>().HasData(GetCategory());
            base.OnModelCreating(modelBuilder);
        }
        private Film[] GetFilm()
        {
            return new Film[]
            {
                new Film {Id = 1, Title = "Titanic", CategoryId = 1},
                new Film {Id = 2, Title = "Poranek Kojota", CategoryId = 2}
            };
        }
        private Actor[] GetActor()
        {
            return new Actor[]
            {
                new Actor {Id = 1, ActorName = "Kate Winslet", FilmId = 1},
                new Actor {Id = 2, ActorName = "Maciej Sztuhr", FilmId = 2}
            };
        }

        private Year[] GetYear()
        {
            return new Year[]
            {
                new Year {Id = 1, YearProduction = 1997},
                new Year {Id = 2, YearProduction = 2001}
            };
        }
        private Category[] GetCategory()
        {
            return new Category[]
            {
                new Category {Id = 1, Genre = "Romance"},
                new Category {Id = 2, Genre = "Comedy"}
            };
        }
    }
}
