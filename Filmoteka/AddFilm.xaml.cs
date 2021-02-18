using System.Windows;
using System.Windows.Controls;
using FilmotekaData;

namespace Filmoteka
{
    /// <summary>
    /// Interaction logic for AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        FilmContext filmContext;
        Film newFilm = new Film();
        Actor newActor = new Actor();
        Year newYear = new Year();
        Category newCategory = new Category();

        public AddFilm(FilmContext filmContext)
        {
            InitializeComponent();
            this.filmContext = filmContext;

            //AddNewFilm.DataContext = newFilm;
        }
        public AddFilm() { }

        private void AddItem(object s, RoutedEventArgs e)
        {
            filmContext.Films.Add(newFilm);
            filmContext.SaveChanges();
            //RefreashViews();

            string messageAdd = "Add new Film: \n" + "ID: " + newFilm.Id + "; Title: " + newFilm.Title;
            string captionAdd = "Add new Film";
            MessageBoxButton buttonAdd = MessageBoxButton.OK;
            MessageBoxImage iconAdd = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageAdd, captionAdd, buttonAdd, iconAdd);

            //clearTextBox(AddNewFilm);
            newFilm = new Film();

            //AddNewFilm.DataContext = newFilm;

            //RefreashViews();
        }
        private void clearTextBox(Grid gridName)
        {
            foreach (Control txtBox in gridName.Children)
            {
                if (txtBox.GetType() == typeof(TextBox))
                    ((TextBox)txtBox).Text = string.Empty;
                if (txtBox.GetType() == typeof(PasswordBox))
                    ((PasswordBox)txtBox).Password = string.Empty;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            filmContext.Films.Add(newFilm);
        }
    }
}
