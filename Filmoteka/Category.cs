using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

namespace Filmoteka
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string  Genre { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
        public virtual ICollection<Years> Years
        { get; private set; } = new ObservableCollection<Years>();
        public virtual ICollection<Actor> Actors
        { get; private set; } = new ObservableCollection<Actor>();
    }
}
