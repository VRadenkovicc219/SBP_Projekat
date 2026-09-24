namespace Skoslki_dnevnik.Entiteti.KompozitniKljucevi
{
    [Serializable]
    public class TelefonId
    {
        public virtual required Osoba OsobaTelefon { get; set; }
        public virtual required string BrojTelefona { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            if (obj is not TelefonId other) return false;

            if (OsobaTelefon?.Id == null || other.OsobaTelefon?.Id == null) return false;

            return OsobaTelefon.Id.Equals(other.OsobaTelefon.Id) && BrojTelefona == other.BrojTelefona;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + OsobaTelefon.Id.GetHashCode();
                hash = hash * 23 + (BrojTelefona?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
