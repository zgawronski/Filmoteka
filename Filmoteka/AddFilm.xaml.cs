using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window, INotifyPropertyChanged
    {
        FilmContext filmContext { get; set; }
        
        public event Action filmAddedEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Year> Years { get; set; } = new List<Year>();
        public List<Actor> Actors { get; set; } = new List<Actor>();


        public AddFilm(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            
        }
        


        
        private void PlusFilm(object s, RoutedEventArgs e)
        {

            if (genreData.SelectedItem != null && yearData.SelectedItem != null && !string.IsNullOrEmpty(filmData.Text) && actorData.SelectedItem != null)
            {
                var newFilm = new Film();
                newFilm.Actor = (Actor)actorData.SelectedItem;
                newFilm.Year = (Year)yearData.SelectedItem;
                newFilm.Category = (Category)genreData.SelectedItem;
                newFilm.Title = filmData.Text;

                filmContext.Films.Add(newFilm);
                filmContext.SaveChanges();
                
                string mAdd = "New Film Added \n";
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);

                filmAddedEvent?.Invoke();
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

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Categories = filmContext.Categories.ToList();
            OnPropertyChanged(nameof(Categories));
            Years = filmContext.Years.ToList();
            OnPropertyChanged(nameof(Years));
            Actors = filmContext.Actors.ToList();
            OnPropertyChanged(nameof(Actors));
        }
    }
}
