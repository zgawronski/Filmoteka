using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

namespace Filmoteka
{
    public class Category
    {
        
        public int Id { get; set; }
        public string  Genre { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
        
    }
}
