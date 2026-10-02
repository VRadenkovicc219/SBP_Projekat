namespace Skoslki_dnevnik.Entiteti
{
    public class RukovodeceOsoblje : Nastavnik
    {
        public virtual RukovodecaPozicija Pozicija { get; set; }
        public virtual DateTime DatumPreuzimanjaFunkcije { get; set; } = DateTime.Now;
        public virtual OblastOdgovornosti OblastOdgovornosti { get; set; }
        public virtual int BrojGodinaRukovodecegStaza { get; set; }
    }
}
