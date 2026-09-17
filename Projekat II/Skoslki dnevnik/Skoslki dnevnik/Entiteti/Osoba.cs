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
        public virtual required String Ime { get; set; }
        public virtual required String Prezime { get; set; }
        public virtual required String JMBG { get; set; }
        public virtual required String Adresa { get; set; }
        public virtual char Pol { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual required String Email { get; set; }
        public virtual String? Komentar { get; set; }
        public virtual ISet<OsobaTelefon> Telefoni { get; set; } = new HashSet<OsobaTelefon>();

        public Osoba(){}
    }
}
