﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmotekaData
{
    /// <summary>
    /// Movie table
    /// </summary>
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int YearId { get; set; }
        public virtual Year Year { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        
    }
}
