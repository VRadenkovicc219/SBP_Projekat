
namespace Skoslki_dnevnik.Entiteti
{
    public class Ucenik : Osoba
    {
        public virtual StatusUcenika Status { get; set; }
        public virtual required string GodinaUpisa { get; set; }
    }
}
