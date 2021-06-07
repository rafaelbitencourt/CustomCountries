using CustomCountries.API.Models;
using CustomCountries.API.Repositories;
using CustomCountries.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCountries.Test
{
    public class RepCountryFake : IRepCountry
    {
        private readonly List<Country> _countries;
        public RepCountryFake()
        {
            _countries = new List<Country>()
            {
                new Country()
                {
                    NumericCode = "0001",
                    Capital = "Brasília",
                    Area = 8515767,
                    Population = 206135893,
                    PopulationDensity = 24.20638011819722M
                },
                new Country()
                {
                    NumericCode = "0003",
                    Capital = "Beijing",
                    Area = 9640011,
                    Population = 1377422166,
                    PopulationDensity = 142.8859537608411M
                },
                new Country()
                {
                    NumericCode = "0004",
                    Capital = "Santiago",
                    Area = 756102,
                    Population = 18191900,
                    PopulationDensity = 24.06011358255897M
                }
            };
        }

        public IQueryable<Country> GetCountries() =>
            _countries.AsQueryable();

       
        public Country GetCountryByNumericCode(string numericCode) =>
            _countries.Where(p => p.NumericCode == numericCode).FirstOrDefault();

        public void removeCountry(Country country) =>
            _countries.Remove(country);
        

        public void saveCountry(Country country) =>
            _countries.Add(country);
    }
}
