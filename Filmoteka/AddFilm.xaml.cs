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
        FilmContext filmContext { get; set; }
        Film newFilm = new Film();
        
        public AddFilm(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            GetCategory();
            GetFilm();
            GetYear();
            GetActor();

        }
        private void GetCategory() => genreData.ItemsSource = filmContext.Categories.Select(g => new { g.Id, Genre = g.Genre }).ToList();
        private void GetFilm() => filmContext.Films.Select(f => new { Id = f.Id, Title = f.Title == filmData.Text }).ToList();
        private void GetYear() => yearData.ItemsSource = filmContext.Years.Select(y => new { YearId = y.Id, Year = y.YearProduction }).ToList();
        private void GetActor() => actorData.ItemsSource = filmContext.Actors.Select(a => new { a.Id, Actor = a.ActorName }).ToList();


        private void PlusFilm(object s, RoutedEventArgs e)
        {
            if (newFilm.Title != null && newFilm.Actor != null && newFilm.Category != null && newFilm.Year != null)
            {
                filmContext.Films.Add(newFilm);
                filmContext.SaveChanges();

                string mAdd = "Add new Film: \n" + "Title: " + newFilm.Title + ", Genre: " + newFilm.Category + ", Year of Production: " + newFilm.Year + ", Actor: " + newFilm.Actor;
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);
                newFilm = new Film();
                
                //filmData.Text = string.Empty;
            }
            else
            {
                string mAdd = "Please provide all details";
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);
            }
         
            
            
        }
    }
}
