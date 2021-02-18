using System;
using System.Windows;
using System.Windows.Controls;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for FilmotekaStart.xaml
    /// </summary>
    public partial class FilmotekaStart : Page
    {
        private readonly FilmHome filmHome;

        public FilmotekaStart(FilmHome filmHome)
        {
            InitializeComponent();
            this.filmHome = filmHome;
        }

        
        // ---< region : Button >---
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // navigate to next page
            //Uri filmHome = new Uri("FilmHome.xaml", UriKind.Relative);

            // Get the navigation service that was used to
            // navigate to this page, and navigate to
            // AnotherPage.xaml
            this.NavigationService.Navigate(filmHome);
        }

    }
}
