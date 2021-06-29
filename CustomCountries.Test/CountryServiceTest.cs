using CustomCountries.API.Models;
using CustomCountries.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomCountries.Test
{
    public class CountryServiceTest
    {
        [Fact]
        public void GetCountries_List_ReturnAllCountries()
        {
            var countryService = GetCountryService();

            var countries = countryService.GetCountries();

            Assert.True(countries.Any());
        }

        [Fact]
        public void RemoveCountry_ByNumericCode_ReturnCountry()
        {
            var countryService = GetCountryService();

            var country = countryService.RemoveCountry(new Country
            {
                NumericCode = "0001"
            });

            Assert.True(country is Country);
        }

        [Fact]
        public void RemoveCountry_NonexistentNumericCode_ReturnArgumentException()
        {
            var countryService = GetCountryService();

            Action action = () => countryService.RemoveCountry(new Country
            {
                NumericCode = "0002"
            });

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [InlineData("0001")]
        [InlineData("0002")]
        public void SaveCountry_New_ReturnCountry(string numericCode)
        {
            var countryService = GetCountryService();

            var country = countryService.SaveCountry(new Country
            {
                NumericCode = numericCode,
                Area = 2780400,
                Capital = "Buenos Aires",
                Population = 43590400,
                PopulationDensity = 15.67774420946626M
            });

            Assert.True(country is Country);
        }

        private ICountryService GetCountryService() => new CountryService(new RepCountryFake());
    }
}