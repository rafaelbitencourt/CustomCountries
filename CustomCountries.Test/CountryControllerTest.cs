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
        public void GetCountries_List_ReturnTrue()
        {
            var countries = _countryService.GetCountries();

            Assert.False(countries.Count() == 0, "Não listou os países");
        }
    }
}
