using CustomCountries.API.Models;
using CustomCountries.API.Services;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CustomCountries.API.GraphQl.Queries
{
    [ExtendObjectType(Name = "QueriesCustomContries")]
    public class CountryQuery
    {
        [UseFiltering]
        public IQueryable<Country> GetCountries([Service]DataBaseContext _dbContext,
            [Service] ICountryService countryService) =>
            countryService.GetCountries(_dbContext);
    }
}
