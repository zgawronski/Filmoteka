using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmotekaData;
using System.Collections;
using System.Collections.Generic;

namespace Filmoteka
{
    /// <summary>
    /// This Class displays the database
    /// </summary>
    public partial class FilmHome : Page
    {
        FilmContext filmContext;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filmContext"></param>
        public FilmHome(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;
            DataContext = this;
            GetFilm();
        }
        /// <summary>
        /// Database view creation method
        /// </summary>
        private void GetFilm() => filmGrid.ItemsSource = filmContext.Films.Select(f => new { f.Id, f.Title, f.CategoryId, Category = f.Category.Genre, f.ActorId, Actors = f.Actor.ActorName, f.YearId, Year = f.Year.YearProduction }).ToList();

        /// <summary>
        /// Method to open AddFilm Window - button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilmAdd(object sender, RoutedEventArgs e)
        {            
            AddFilm addFilm = new AddFilm(filmContext);
            addFilm.filmAddedEvent += AddFilm_filmAddedEvent;
            addFilm.Show();
        }
        /// <summary>
        /// Database view refresh method
        /// </summary>
        private void AddFilm_filmAddedEvent()
        {
            GetFilm();
        }

    }
}
