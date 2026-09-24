namespace Skoslki_dnevnik.Entiteti
{
    public class RukovodeceOsoblje : Nastavnik
    {
        public virtual RukovodecaPozicija Pozicija { get; set; }
        public virtual DateOnly DatumPreuzimanjaFunkcije { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public virtual OblastOdgovornosti OblastOdgovornosti { get; set; }
        public virtual int BrojGodinaRukovodecegStaza { get; set; }
    }
}
