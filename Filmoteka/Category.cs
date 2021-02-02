using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Filmoteka
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();

    }
}
