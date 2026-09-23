using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Nastavnik : Osoba
    {
        public virtual StatusNastavnika Status { get; set; }
        public virtual required string Zvanje { get; set; }
        public virtual required string StrucnaSprema { get; set; }
        public virtual DateOnly DatumZaposlenja { get; set; }
        public virtual IList<Predmet> Predmeti { get; set; } = new List<Predmet>();
    }
}
