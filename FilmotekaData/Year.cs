using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmotekaData
{
    /// <summary>
    /// Production years table
    /// </summary>
    public class Year
    {
        public int Id { get; set; }
        public int YearProduction { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
    }
}
