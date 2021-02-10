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
            GetFilm();
            //categoryViewSource =
            //    (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void GetFilm()
        {
            Film.categoryViewSource = filmContext.Films.ToList();
        }
        /* private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Categories.Load();

            // bind to the source
            categoryViewSource.Source =
                _context.Categories.Local.ToObservableCollection();
        }*/
        

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
        //    // clean up database connections
        //    _context.Dispose();
        //    base.OnClosing(e);
        //}
    }
}
