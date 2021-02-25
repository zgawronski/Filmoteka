using FilmotekaData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Filmoteka
{
    /// <summary>
    /// Startup Application
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        /// <summary>
        /// Database setup Constructor
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<FilmContext>(option =>
            {
                option.UseSqlite("Data Source = films.db");
                option.UseLazyLoadingProxies();
            });
            services.AddSingleton<FilmHome>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<FilmotekaStart>();
            services.AddSingleton<AddFilm>();
            serviceProvider = services.BuildServiceProvider(); 
        }
        /// <summary>
        /// Setting the Boot window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var startWindow = serviceProvider.GetRequiredService<MainWindow>();
            startWindow.Show();
        }
    }

}

