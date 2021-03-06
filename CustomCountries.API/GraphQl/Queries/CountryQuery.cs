using CustomCountries.API.Models;
using HotChocolate;
using System.Linq;

namespace CustomCountries.API.Queries
{
    public class CountryQuery
    {
        public IQueryable<Country> GetCountries([Service]DataBaseContext _dbContext) =>
            _dbContext.Countries;
    }
}
