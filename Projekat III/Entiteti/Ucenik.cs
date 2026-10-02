namespace Skoslki_dnevnik.Entiteti
{
    public class Ucenik : Osoba
    {
        public virtual StatusUcenika Status { get; set; }
        public virtual required string GodinaUpisa { get; set; }
        public virtual IList<Odeljenje> Odeljenja { get; set; } = new List<Odeljenje>();
        public virtual IList<Predmet> Predmeti { get; set; } = new List<Predmet>();
        public virtual IList<Ocena> Ocene { get; set; } = new List<Ocena>();
        public virtual IList<Izostanak> Izostanci { get; set; } = new List<Izostanak>();
        public virtual IList<RoditeljStaratelj> Roditelji { get; set; } = new List<RoditeljStaratelj>();
    }
}
