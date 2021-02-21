using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        FilmContext filmContext;
        Film newFilm = new Film();
        
        public AddFilm(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            //GetFilm();
            GetActor();
            GetYear();
            GetCategory();

        }
        //private void GetFilm() => FilmTextBox.ItemsSource = filmContext.Films.Select(film => new { Id = film.Id, Title = film.Title }).ToList();
        private void GetActor() => actorData.ItemsSource = filmContext.Actors.Select(a => new { a.ActorName }).ToList();
        private void GetYear() => yearData.ItemsSource = filmContext.Years.Select(y => new { y.YearProduction }).ToList();
        private void GetCategory() => genreData.ItemsSource = filmContext.Categories.Select(g => new { g.Genre }).ToList();


        private void PlusFilm(object s, RoutedEventArgs e)
        {
            filmContext.Films.Add(newFilm);
            filmContext.SaveChanges();
         
            newFilm = new Film();
                      
            FilmTextBox.Text = string.Empty;
            
        }
    }
}
