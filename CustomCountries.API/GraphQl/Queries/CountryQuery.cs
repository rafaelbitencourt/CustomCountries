using CustomCountries.API.Models;
using CustomCountries.API.Services;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using System.Linq;

namespace CustomCountries.API.GraphQl.Queries
{
    [ExtendObjectType(Name = "QueriesCustomContries")]
    public class CountryQuery
    {
        [Authorize]
        [UseFiltering]
        public IQueryable<Country> GetCountries([Service] ICountryService countryService) =>
            countryService.GetCountries();
    }
}
