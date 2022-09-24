
namespace Collections
{
    class Country
    {
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public static void Print(List<Country> countries)
        {
            foreach (Country country in countries)
            {
                Console.WriteLine(country);    
            }
            Console.WriteLine($"Count: {countries.Count}");
            Console.WriteLine($"Capacity: {countries.Capacity}");
            Console.WriteLine("------------------------------------");    

        }
        public override string ToString()
        {
            return $"{Name} -- {ISOCode}";
        }
        public override int GetHashCode()
        {
            unchecked
            { 
            var hash = 7;
            hash = hash * 11 + ISOCode.GetHashCode();
            hash = hash * 11 + Name.GetHashCode();
            return hash;
            }
        }
        public override bool Equals(object? obj)
        {
            var country = obj as Country;
            if (country is null) return false; // Better than (country == null)
            return this.Name.Equals(country.Name, StringComparison.OrdinalIgnoreCase) && this.ISOCode.Equals(country.ISOCode, StringComparison.OrdinalIgnoreCase); 
        }
    }
}