namespace Skoslki_dnevnik.Entiteti
{
    public class SlusaPredmet
    {
        public virtual int Id { get; set; }
        public virtual required Ucenik Ucenik { get; set; }
        public virtual required Predmet Predmet { get; set; }   
    }
}
