namespace Skoslki_dnevnik.Entiteti
{
    public class Nastavnik : Osoba
    {
        public virtual StatusNastavnika Status { get; set; }
        public virtual required string Zvanje { get; set; }
        public virtual required string StrucnaSprema { get; set; }
        public virtual DateTime DatumZaposlenja { get; set; }
        public virtual IList<Predaje> Predaje { get; set; } = new List<Predaje>();
    }
}
