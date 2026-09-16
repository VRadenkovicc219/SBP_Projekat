namespace Skoslki_dnevnik.Entiteti
{
    public class Ocena
    {
        public virtual int Id { get; protected set; }
        public virtual int Vrednost { get; set; }
        public virtual TipOcene Tip { get; set; }
        public virtual DateOnly DatumOcenjivanja { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public virtual int Polugodje { get; set; }
        public virtual string? Komentar { get; set; }
        public required Ucenik Ucenik { get; set;  }
        public required Nastava Nastava{ get; set; }
    }
}
