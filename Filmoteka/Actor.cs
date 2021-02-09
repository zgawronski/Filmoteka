using System;
using System.Collections.Generic;
using System.Text;

namespace Filmoteka
{
    public class Actor
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
}
