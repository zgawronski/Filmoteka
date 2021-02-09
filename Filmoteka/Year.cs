using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmoteka
{
    public class Year
    {
        public int Id { get; set; }
        public int YearProduction { get; set; }
        public virtual ICollection<Film> Actors
        { get; private set; } = new ObservableCollection<Film>();
    }
}
