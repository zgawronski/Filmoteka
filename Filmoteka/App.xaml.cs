using FilmotekaData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {

            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<FilmContext>(option =>
            {
                option.UseSqlite("Data Source = films.db");
                option.UseLazyLoadingProxies();
            });
            services.AddSingleton<FilmHome>();

            serviceProvider = services.BuildServiceProvider();
        }
        
    }

}

