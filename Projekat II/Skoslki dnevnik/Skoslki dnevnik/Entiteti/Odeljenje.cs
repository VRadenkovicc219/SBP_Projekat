using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Odeljenje
    {
        public required string Oznaka { get; set; }
        public required string SkolskaGodina { get; set; }
        public required int Razred { get; set; }
    }
}
