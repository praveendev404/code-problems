using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class LazyLoading
    {
        static void Main1(string[] args)
        {
            LazyLoading olazyLoading = new LazyLoading(); //  object not loaded
            Console.WriteLine();

            foreach (Country c in olazyLoading.lstCountries) // Load  object only at this moment
            {
                Console.WriteLine(c.CountryName);
            }
            Console.ReadKey();
        }

        private Lazy<List<Country>> _countries = null;

        public LazyLoading()
        {
            // You can call from database
            _countries = new Lazy<List<Country>>(() => GetCountries());
        }

        public List<Country> lstCountries
        {
            get
            {
                return _countries.Value;
            }

        }

        List<Country> GetCountries()
        {
            List<Country> lstCountry = new List<Country>() { 
            new Country(){CountryId=1,CountryName="India"},
            new Country(){CountryId=1,CountryName="USA"},
            new Country(){CountryId=1,CountryName="Canada"},
            new Country(){CountryId=1,CountryName="Mexico"},
            };
            return lstCountry;
        }

    }


    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }

}
