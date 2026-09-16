using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class StrucniSaradnik : Nastavnik
    {
        public virtual required string Licenca{ get; set; }
        public virtual required string StrucnaOblast{ get; set; }
        public virtual int BrojSprovedenihRazgovora { get; set; } = 0;

    }
}
