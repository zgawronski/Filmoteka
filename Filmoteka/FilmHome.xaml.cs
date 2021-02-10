using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for FilmHome.xaml
    /// </summary>
    public partial class FilmHome : Page
    {
        //private readonly FilmContext _context =
        //    new FilmContext();

        //private CollectionViewSource categoryViewSource;
        private readonly FilmContext filmContext;
        

        public FilmHome(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            /*GetFilm();
            GetActor();
            GetYear();
            GetCategory();*/
            //categoryViewSource =
             //   (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }
        /*
        private void GetFilm() => Film.Title = filmContext.Films.ToList();
        private void GetActor() => Actor.ActorName = filmContext.Actors.ToList();
        private void GetYear() => Year.YearProduction = filmContext.Years.ToList();
        private void GetCategory() => Category.Genre = filmContext.Categories.ToList();
        */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            filmContext.Database.EnsureCreated();

            // load the entities into EF Core
            filmContext.Films.Load();
            filmContext.Actors.Load();
            filmContext.Years.Load();
            filmContext.Categories.Load();

            //// bind to the source
            filmContext.Films = filmContext.Films.Local.ToObservableCollection();
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

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    clean up database connections
        //    filmContext.Dispose();
        //    base.OnClosing(e);
        //}
    }
}
