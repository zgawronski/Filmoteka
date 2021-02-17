using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FilmotekaData;
using System.ComponentModel;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for FilmHome.xaml
    /// </summary>
    public partial class FilmHome : Page
    {
        private readonly FilmContext filmContext;

        Film newFilm = new Film();
        Actor newActor = new Actor();
        Year newYear = new Year();
        Category newCategory = new Category();

        public FilmHome(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            GetFilm();
            GetActor();
            GetYear();
            GetCategory();
            //DisplayFilmList()



        }
        public FilmHome() { }

        /* private void DisplayFilmList()
        {
            var film = from b in filmContext.Films select new { Id = b.Id, Title = b.Title };
            FilmTitle.ItemSource = film.ToList();

        } */
        private void GetFilm() => filmsDataGrid.ItemsSource = filmContext.Films.ToList();
        private void GetActor() => actorsDataGrid.ItemsSource = filmContext.Actors.ToList();
        private void GetYear() => yearsDataGrid.ItemsSource = filmContext.Years.ToList();
        private void GetCategory() => categoryDataGrid.ItemsSource = filmContext.Categories.ToList();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //// load the entities into EF Core
            filmContext.Films.Load();
            filmContext.Actors.Load();
            filmContext.Years.Load();
            filmContext.Categories.Load();

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // this forces the grid to refresh to latest values
             categoryDataGrid.Items.Refresh();
             filmsDataGrid.Items.Refresh();
             yearsDataGrid.Items.Refresh();
             actorsDataGrid.Items.Refresh(); 
           
        }
       

    }
}
