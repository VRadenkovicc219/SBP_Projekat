namespace Skoslki_dnevnik.Entiteti
{
    public class RazredniStaresina : Nastavnik
    {
        public virtual required Odeljenje Odeljenje { get; set; }
        public virtual DateOnly DatumPreuzimanjaStaresinstva { get; set; }
        public virtual int BrojOdrzanihSasatanaka { get; set; } = 0;
        public virtual string? Napomena { get; set; }

    }
}
