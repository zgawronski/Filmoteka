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
        Actor newActor = new Actor();
        Year newYear = new Year();
        Category newCategory = new Category();

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
        private void GetActor() => actorData.ItemsSource = filmContext.Actors.Select(actor => new {Actor = actor.ActorName }).ToList();
        private void GetYear() => yearData.ItemsSource = filmContext.Years.Select(year => new {Year = year.YearProduction }).ToList();
        private void GetCategory() => genreData.ItemsSource = filmContext.Categories.Select(genre => new {Genre = genre.Genre }).ToList();
        private void AddItem(object s, RoutedEventArgs e)
        {
            filmContext.Films.Add(newFilm);
            filmContext.SaveChanges();
            //RefreashViews();

            string messageAdd = "Add new Film: \n" + "ID: " + newFilm.Id + "; Title: " + newFilm.Title;
            string captionAdd = "Add new Film";
            MessageBoxButton buttonAdd = MessageBoxButton.OK;
            MessageBoxImage iconAdd = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageAdd, captionAdd, buttonAdd, iconAdd);

            newFilm = new Film();
            
            FilmTextBox.Text = string.Empty;
            

            //RefreashViews();
        }
    }
}
