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

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for FilmHome.xaml
    /// </summary>
    public partial class FilmHome : Page
    {
        private readonly FilmContext filmContext;
        public FilmHome(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            GetFilm();
            GetActor();
            GetYear();
            GetCategory();
        }
        private void GetFilm() => filmsDataGrid.ItemsSource = filmContext.Films.ToList();
        private void GetActor() => actorsDataGrid.ItemsSource = filmContext.Actors.ToList();
        private void GetYear() => yearsDataGrid.ItemsSource = filmContext.Years.ToList();
        private void GetCategory() => categoryDataGrid.ItemsSource = filmContext.Categories.ToList();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            filmContext.Database.EnsureCreated();

            //// load the entities into EF Core
            filmContext.Films.Load();
            filmContext.Actors.Load();
            filmContext.Years.Load();
            filmContext.Categories.Load();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            // _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            filmsDataGrid.Items.Refresh();
            yearsDataGrid.Items.Refresh();
            actorsDataGrid.Items.Refresh();
        }

    }
}
