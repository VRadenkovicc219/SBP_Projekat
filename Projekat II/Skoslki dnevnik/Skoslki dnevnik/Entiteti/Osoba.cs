using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; protected set; }
        public virtual String Ime { get; set; } = String.Empty;
        public virtual String Prezime { get; set; } = String.Empty;
        public virtual String JMBG { get; set; } = String.Empty;
        public virtual String Adresa { get; set; } = String.Empty;
        public virtual char Pol { get; set; }
        public virtual DateOnly DatumRodjenja { get; set; }
        public virtual String Email { get; set; } = String.Empty;
        public virtual String? Komentar { get; set; }
    }
}
