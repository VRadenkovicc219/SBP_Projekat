using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Odeljenje
    {
        public virtual int Id { get; protected set; }
        public required string Oznaka { get; set; }
        public required string SkolskaGodina { get; set; }
        public required int Razred { get; set; }
        public IList<Nastava> Predmeti { get; set; } = new List<Nastava>();
        public IList<Ucenik> Ucenici { get; set; } = new List<Ucenik>();

    }
}
