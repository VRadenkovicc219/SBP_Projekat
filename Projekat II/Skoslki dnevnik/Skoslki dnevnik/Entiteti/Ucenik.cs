
using System.Configuration;

namespace Skoslki_dnevnik.Entiteti
{
    public class Ucenik : Osoba
    {
        public virtual StatusUcenika Status { get; set; }
        public virtual required string GodinaUpisa { get; set; }
        public virtual IList<UcenikOdeljenje> Odeljenja{ get; set; } = new List<UcenikOdeljenje>();
        public virtual IList<SlusaPredmet> Predmeti{ get; set; } = new List<SlusaPredmet>();
        public virtual IList<Ocena> Ocene { get; set; } = new List<Ocena>();
        public virtual IList<Izostanak> Izostanci { get; set; } = new List<Izostanak>();
        public virtual IList<RoditeljStaratelj> Roditelji { get; set; } = new List<RoditeljStaratelj>();
    }
}
