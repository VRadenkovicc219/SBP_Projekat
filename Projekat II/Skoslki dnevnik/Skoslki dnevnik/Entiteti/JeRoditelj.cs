using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class JeRoditelj
    {
        public virtual required int Id{ get; set; }
        public virtual required RoditeljStaratelj RoditeljStaratelj{ get; set; }
        public virtual required Ucenik Ucenik{ get; set; }
    }
}
