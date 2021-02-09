using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmoteka
{
    public class Years
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
