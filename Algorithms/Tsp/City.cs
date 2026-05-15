namespace XBIOM.Algorithms.Tsp
{
    /// <summary>
    /// Reprezentuje město v TSP úloze včetně zeměpisných souřadnic.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Vytvoří město se jménem a souřadnicemi ve stupních.
        /// </summary>
        public City(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { set; get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        /// <summary>
        /// Spočítá vzdálenost k zadané poloze pomocí Haversinova vzorce.
        /// </summary>
        public double GetDistanceFromPosition(double latitude, double longitude)
        {
            const int earthRadiusKm = 6371;
            var dLat = DegreesToRadians(latitude - Latitude);
            var dLon = DegreesToRadians(longitude - Longitude);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(Latitude)) * Math.Cos(DegreesToRadians(latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
               ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = earthRadiusKm * c;
            return d;
        }

        /// <summary>
        /// Převede úhel ze stupňů na radiány.
        /// </summary>
        private static double DegreesToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }

        /// <summary>
        /// Vrátí název města pro výpis trasy.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Porovná města podle názvu a souřadnic.
        /// </summary>
        public override bool Equals(object? obj)
        {
            var item = obj as City;
            return Equals(item);
        }

        /// <summary>
        /// Typově bezpečné porovnání dvou instancí města.
        /// </summary>
        protected bool Equals(City? other)
        {
            if (other is null) return false;
            return string.Equals(Name, other.Name) && Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        /// <summary>
        /// Vrátí hash kód odpovídající porovnání měst podle názvu a souřadnic.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                return hashCode;
            }
        }
    }
}
