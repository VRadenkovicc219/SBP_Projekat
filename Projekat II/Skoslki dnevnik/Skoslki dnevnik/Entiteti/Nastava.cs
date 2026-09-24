namespace Skoslki_dnevnik.Entiteti
{
    public class Nastava
    {
        public virtual int Id { get; set; }
        public virtual required Odeljenje Odeljenje { get; set; }
        public virtual required Predaje predajePredmet { get; set; }
        public virtual IList<Ocena> Ocene { get; set; } = new List<Ocena>();
        public virtual IList<Izostanak> Izostanci { get; set; } = new List<Izostanak>();

    }
}
