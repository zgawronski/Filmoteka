using System;
using System.Collections.Generic;
using System.Text;

namespace Filmoteka
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
