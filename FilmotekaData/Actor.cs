using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FilmotekaData
{
    public class Actor
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
        //public int FilmId { get; set; }
        //public virtual Film Film { get; set; }
        public virtual ICollection<Film> Films
        { get; private set; } = new ObservableCollection<Film>();
    }
}
