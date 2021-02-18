﻿using Microsoft.EntityFrameworkCore;
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
            GetFilm();
            GetActor();
            GetYear();
            GetCategory();

        }
        public FilmHome() { }

        private void GetFilm() => filmsDataGrid.ItemsSource = filmContext.Films.Select(film => new { Id = film.Id, Title = film.Title }).ToList();
        private void GetActor() => actorsDataGrid.ItemsSource = filmContext.Actors.Select(actor => new { Id = actor.Id, ActorName = actor.ActorName}).ToList();
        private void GetYear() => yearsDataGrid.ItemsSource = filmContext.Years.Select(year => new { Id = year.Id, Title = year.YearProduction }).ToList();
        private void GetCategory() => categoryDataGrid.ItemsSource = filmContext.Categories.Select(genre => new { Id = genre.Id, Genre = genre.Genre }).ToList();

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
            // this forces the grid to refresh to latest values
            /*categoryDataGrid.Items.Refresh();
            filmsDataGrid.Items.Refresh();
            yearsDataGrid.Items.Refresh();
            actorsDataGrid.Items.Refresh();
            */
            AddFilm addFilm = new AddFilm(filmContext);
            addFilm.Show();

        }
       

    }
}
