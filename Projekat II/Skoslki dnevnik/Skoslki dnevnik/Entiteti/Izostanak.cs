using Skoslki_dnevnik.Entiteti.KompozitniKljucevi;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Izostanak
    {
        public virtual required IzostanakId Id{ get; set; }
        public virtual TipIzostanka TipIzostanka { get; set; }
        public virtual Opravdao Opravdao { get; set; }
        public virtual string? RazlogIzostanka { get; set; }
        public virtual string? Komentar { get; set; }
        public virtual required Nastava Nastava{ get; set; }
           
    }
}
