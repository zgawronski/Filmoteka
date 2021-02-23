using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;

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
            GetYear();
            GetActor();
            
        }
        private void GetCategory() => genreData.ItemsSource = filmContext.Categories.Select(g => new { GenreId = g.Id, Genre = g.Genre }).ToList();
        private void GetYear() => yearData.ItemsSource = filmContext.Years.Select(y => new { YearId = y.Id, Year = y.YearProduction }).ToList();
        private void GetActor() => actorData.ItemsSource = filmContext.Actors.Select(a => new { ActorId = a.Id, Actor = a.ActorName }).ToList();


        private void PlusFilm(object s, RoutedEventArgs e)
        {
            newFilm.Title = filmData.Text;
            newFilm.CategoryId = Convert.ToInt32(genreData.HasItems);
            newFilm.YearId = Convert.ToInt32(yearData.HasItems);
            newFilm.ActorId = Convert.ToInt32(actorData.HasItems);

            if (newFilm.CategoryId != 0 && newFilm.YearId != 0 && newFilm.Title != null && newFilm.ActorId != 0)
            {
                filmContext.Films.Add(newFilm);
                filmContext.SaveChanges();

                string mAdd = "New FilmAdded \n";
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);
                newFilm = new Film();
                
                filmData.Text = string.Empty;
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
