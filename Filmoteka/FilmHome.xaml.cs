using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for FilmHome.xaml
    /// </summary>
    public partial class FilmHome : Page
    {
        FilmContext filmContext;


        public FilmHome(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            GetFilm();
            

        }

        private void GetFilm() => filmGrid.ItemsSource = filmContext.Films.Select(f => new { f.Id, f.Title, f.CategoryId, Category = f.Category.Genre, f.ActorId, Actors = f.Actor.ActorName, f.YearId, Year = f.Year.YearProduction }).ToList();
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //// load the entities into EF Core
            filmContext.Films.Load();
            filmContext.Actors.Load();
            filmContext.Years.Load();
            filmContext.Categories.Load();

        }
        
        // open AddFilm Window

        private void FilmAdd(object sender, RoutedEventArgs e)
        {            
            AddFilm addFilm = new AddFilm(filmContext);
            addFilm.Show();
        }
       

    }
}
