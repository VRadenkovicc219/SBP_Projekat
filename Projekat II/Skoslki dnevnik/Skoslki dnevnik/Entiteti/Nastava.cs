using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Nastava
    {
        public virtual int Id{ get; set; }
        public virtual required Odeljenje Odeljenje { get; set; }
        public virtual required Predmet Predmet { get; set; }
        public virtual required Nastavnik Nastavnik { get; set; }
    }
}
