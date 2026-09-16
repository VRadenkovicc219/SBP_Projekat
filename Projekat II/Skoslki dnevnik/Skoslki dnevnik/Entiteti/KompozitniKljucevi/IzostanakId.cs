using NHibernate.Linq.Visitors.ResultOperatorProcessors;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Skoslki_dnevnik.Entiteti.KompozitniKljucevi
{
    public class IzostanakId
    {
        public virtual required Ucenik Ucenik { get; set; }
        public virtual DateOnly Datum { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public virtual int RedniBrojCasa { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is null) 
                return false;
            
            if (Object.ReferenceEquals(this, obj)) 
                return true;

            if (obj.GetType() != typeof(IzostanakId))
                return false;

            IzostanakId temp = (IzostanakId)obj;

            if (Ucenik.Id == temp.Ucenik.Id && temp.Datum.CompareTo(Datum) == 0 && temp.RedniBrojCasa == RedniBrojCasa)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
