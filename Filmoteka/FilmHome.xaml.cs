using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;
using System.Collections;
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
        
        // open AddFilm Window

        private void FilmAdd(object sender, RoutedEventArgs e)
        {            
            AddFilm addFilm = new AddFilm(filmContext);
            addFilm.filmAddedEvent += AddFilm_filmAddedEvent;
            addFilm.Show();
        }

        private void AddFilm_filmAddedEvent()
        {
            GetFilm();
        }

    }
}
