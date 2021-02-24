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
        private void GetCategory() => genreData.ItemsSource = filmContext.Categories.Select(g => new { g.Id, Genre = g.Genre }).ToList();
        private void GetYear() => yearData.ItemsSource = filmContext.Years.Select(y => new { y.Id, Year = y.YearProduction }).ToList();
        private void GetActor() => actorData.ItemsSource = filmContext.Actors.Select(a => new { a.Id, Actor = a.ActorName }).ToList();


        private void PlusFilm(object s, RoutedEventArgs e)
        {
            newFilm.Title = filmData.Text;
            char[] c = { '{', 'I', 'd', '=', ' ' };
            string item = genreData.SelectedItem.ToString();

            string id = item.Split(',')[0];
            int Id = Int32.Parse(id.Trim(c));

            string item2 = yearData.SelectedItem.ToString();
            string id2 = item2.Split(',')[0];

            int Id2 = Int32.Parse(id2.Trim(c));
            string item3 = actorData.SelectedItem.ToString();

            string id3 = item3.Split(',')[0];
            int Id3 = Int32.Parse(id3.Trim(c));

            newFilm.CategoryId = Id;
            newFilm.YearId = Id2;
            newFilm.ActorId = Id3;

            if (newFilm.CategoryId != 0 && newFilm.YearId != 0 && newFilm.Title != null && newFilm.ActorId != 0)
            {
                filmContext.Films.Add(newFilm);
                filmContext.SaveChanges();
                filmContext.UpdateRange();
                string mAdd = "New Film Added \n";
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);
                newFilm = new Film();
                
                this.Close();
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
