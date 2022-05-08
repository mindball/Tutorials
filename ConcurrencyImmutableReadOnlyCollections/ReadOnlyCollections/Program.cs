using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ReadOnlyCollections
{
    internal class Program
    {
        public static ReadOnlyCollection<Country> AllCountries { get; private set; }

        public static ReadOnlyDictionary<CountryCode, Country> AllCountriesByKey
        { get; private set; }

        static void Main(string[] args)
        {
            var countries = ReadAllCountries();
            //AllCountries = new ReadOnlyCollection<Country>(countries);
            AllCountries = countries.AsReadOnly();
            //AllCountries .Add .Remote and etc. not exposed

            countries.Add(new Country()); //Read-only collections can be modified - if you have a reference to the underlying collection
            //if somewhere AllCountries list, this record will appear

            var dict = ReadAllCountries().ToDictionary(x => x.Code);
            AllCountriesByKey = new ReadOnlyDictionary<CountryCode, Country>(dict);
        }

        private static List<Country> ReadAllCountries()
        {
            return new List<Country>();
        }
    }
}
