using CustomCountries.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Services
{
    public class CountryService
    {
		private readonly RepositoryContext _dbContext;

		public CountryService(RepositoryContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<Country> GetSomeData() =>
				_dbContext.Countries;
	}
}
