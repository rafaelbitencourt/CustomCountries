using CustomCountries.API.Models;
using CustomCountries.API.Repository;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CustomCountries.API.GraphQl.Queries
{
    public class CountryQuery
    {
        [UseFiltering]
        public IQueryable<Country> GetCountries([Service]DataBaseContext _dbContext,
            [Service] CountryService countryService) =>
            countryService.GetCountries(_dbContext);
    }
}
