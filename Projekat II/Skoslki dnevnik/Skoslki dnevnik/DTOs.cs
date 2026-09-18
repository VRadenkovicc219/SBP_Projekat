using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik
{
    public record UcenikDTO(int id, string ime, string prezime, string JMBG, string adresa, string status);
}
