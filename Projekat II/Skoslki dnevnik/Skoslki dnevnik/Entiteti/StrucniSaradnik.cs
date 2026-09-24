namespace Skoslki_dnevnik.Entiteti
{
    public class StrucniSaradnik : Nastavnik
    {
        public virtual required string Licenca { get; set; }
        public virtual StrucnaOblast StrucnaOblast { get; set; }
        public virtual int BrojSprovedenihRazgovora { get; set; } = 0;
        public virtual int BrojOdrzanihRadionica { get; set; } = 0;
    }
}
