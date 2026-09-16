using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class TelefonId
    {
        public virtual required Osoba OsobaTelefon { get; set; }
        public virtual required string BrojTelefona { get; set; }

        public override bool Equals(object obj)
        {
            if(Object.ReferenceEquals(this, obj)) 
                return true;
            if (obj.GetType() != typeof(TelefonId))
                return false;

            TelefonId other = (TelefonId)obj;
            if ((OsobaTelefon.Id == other.OsobaTelefon.Id) && (BrojTelefona == other.BrojTelefona))
                return true;
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
