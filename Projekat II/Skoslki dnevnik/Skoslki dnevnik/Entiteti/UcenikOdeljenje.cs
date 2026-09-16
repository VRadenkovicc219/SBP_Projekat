using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class UcenikOdeljenje
    {
        public virtual int Id{ get; set; }
        public virtual required Ucenik Ucenik { get; set; }
        public virtual required Odeljenje Odeljenje { get; set; }
    }
}
