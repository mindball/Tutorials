using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ImmutableCollections
{
    internal class Program
    {
        public static ImmutableArray<Country> AllCountries { get; private set; }

        public static ImmutableDictionary<CountryCode, Country> AllCountriesByKey { get; private set; }

        static void Main(string[] args)
        {
            var countries = ReadAllCountries();

            AllCountries = countries.ToImmutableArray();

            AllCountriesByKey = AllCountries.ToImmutableDictionary(x => x.Code);

            countries.Add(new Country()); 
            //if somewhere AllCountries list, this record will NOT appear
        }

        private static List<Country> ReadAllCountries()
        {
            return new List<Country>();
        }
    }
}
