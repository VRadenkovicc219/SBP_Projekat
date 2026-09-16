using Skoslki_dnevnik.Entiteti.KompozitniKljucevi;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Izostanak
    {
        public required IzostanakId Id{ get; set; }
        public TipIzostanka TipIzostanka{ get; set; }
        public Opravdao Opravdao { get; set; }
        public string? Komentar { get; set; }
        public required Nastava Nastava{ get; set; }
    }
}
