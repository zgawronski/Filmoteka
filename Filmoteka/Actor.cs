using System;
using System.Collections.Generic;
using System.Text;

namespace Filmoteka
{
    public class Actor
    {
        public int Id { get; set; }
        public string Actors { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
