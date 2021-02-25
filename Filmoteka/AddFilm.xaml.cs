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
    /// Window for adding a new Movie
    /// </summary>
    public partial class AddFilm : Window, INotifyPropertyChanged
    {
        FilmContext filmContext { get; set; }
        /// <summary>
        /// Film adding event
        /// </summary>
        public event Action filmAddedEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Category list initialization
        /// </summary>
        public List<Category> Categories { get; set; } = new List<Category>();
        /// <summary>
        /// Year list initialization
        /// </summary>
        public List<Year> Years { get; set; } = new List<Year>();
        /// <summary>
        /// Actor list initialization
        /// </summary>
        public List<Actor> Actors { get; set; } = new List<Actor>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filmContext"></param>
        public AddFilm(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            
        }
        /// <summary>
        /// Method of Adding a Film to the Database
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void PlusFilm(object s, RoutedEventArgs e)
        {
            /// Checking the Entered data
            if (genreData.SelectedItem != null && yearData.SelectedItem != null && !string.IsNullOrEmpty(filmData.Text) && actorData.SelectedItem != null)
            {
                /// Extracting variables into the Constructor from the Input Window
                var newFilm = new Film();
                newFilm.Actor = (Actor)actorData.SelectedItem;
                newFilm.Year = (Year)yearData.SelectedItem;
                newFilm.Category = (Category)genreData.SelectedItem;
                newFilm.Title = filmData.Text;
                /// Saving the Added video
                filmContext.Films.Add(newFilm);
                filmContext.SaveChanges();
                /// Window with a message of Added a Movie
                string mAdd = "New Film Added \n";
                string cAdd = "Incorrect data!";
                MessageBoxButton message = MessageBoxButton.OK;
                MessageBoxImage messageBox = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(mAdd, cAdd, message, messageBox);
                /// Invokes a Refresh of the Database view and closes the Window
                filmAddedEvent?.Invoke();
                this.Close();
            }
            else
            {
                /// Window with the message of entering correct data
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
