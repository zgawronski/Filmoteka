using FilmotekaData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Navigation;


namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private readonly FilmotekaStart filmotekaStart;

        public MainWindow(FilmotekaStart filmotekaStart)
        {
            InitializeComponent();
            this.filmotekaStart = filmotekaStart;
            this.Navigate(filmotekaStart);
        }
        
    }
}
