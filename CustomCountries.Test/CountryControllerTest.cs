using CustomCountries.API.Models;
using CustomCountries.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomCountries.Test
{
    public class CountryControllerTest
    {
        private readonly ICountryService _countryService;

        public CountryControllerTest()
        {
            _countryService = new CountryService(new RepCountryFake());
        }

        [Fact]
        public void GetCountries_List_ReturnAllCountries()
        {
            var countries = _countryService.GetCountries();

            Assert.Equal(3, countries.Count());
        }

        [Fact]
        public void RemoveCountry_ReturnCountry()
        {
            var country = _countryService.RemoveCountry(new Country
            {
                NumericCode = "0001"
            });

            Assert.False(country == null);
        }

        [Fact]
        public void SaveCountry_ReturnCountry()
        {
            var country = _countryService.SaveCountry(new Country
            {
                NumericCode = "0002",
                Area = 2780400,
                Capital = "Buenos Aires",
                Population = 43590400,
                PopulationDensity = 15.67774420946626M
            });

            Assert.False(country == null);
        }
    }
}
