using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmotekaData
{
    /// <summary>
    /// Actors Table
    /// </summary>
    public class Actor
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
    }
}
