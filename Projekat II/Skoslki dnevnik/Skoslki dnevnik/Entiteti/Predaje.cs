using Npgsql.PostgresTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class Predaje
    {
        public virtual int Id { get; set; }
        public virtual required Predmet Predmet { get; set; }
        public virtual required Nastavnik Nastavnik { get; set; }
        public virtual List<Nastava> Nastave { get; set; } = new List<Nastava>();
    }
}
