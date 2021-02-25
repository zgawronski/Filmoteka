using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmotekaData
{
    /// <summary>
    /// Table of Film Genres
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string  Genre { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
    }
}
