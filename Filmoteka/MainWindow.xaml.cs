using FilmotekaData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Navigation;


namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private ServiceProvider serviceProvider;

        public MainWindow()
        {
            InitializeComponent();

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
