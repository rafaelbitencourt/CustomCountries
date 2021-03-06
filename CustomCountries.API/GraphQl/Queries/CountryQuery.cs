using CustomCountries.API.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CustomCountries.API.GraphQl.Queries
{
    public class CountryQuery
    {
        [UseFiltering]
        public IQueryable<Country> GetCountries([Service]DataBaseContext _dbContext) =>
            _dbContext.Countries;
    }
}
