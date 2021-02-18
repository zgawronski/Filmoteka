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
    /// Interaction logic for FilmotekaStart.xaml
    /// </summary>
    public partial class FilmotekaStart : Page
    {
        public FilmotekaStart()
        {
            InitializeComponent();
        }

        // ---< region : Button >---
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //FilmHome filmHome = this.FilmHome //new FilmHome();
            //this.NavigationService.Navigate(filmHome);

            // Create a pack URI
            Uri filmHome = new Uri("FilmHome.xaml", UriKind.Relative);

            // Get the navigation service that was used to
            // navigate to this page, and navigate to
            // AnotherPage.xaml
            this.NavigationService.Navigate(filmHome);
        }

    }
}
