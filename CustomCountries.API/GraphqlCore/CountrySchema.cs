using CustomCountries.API.Queries;
using GraphQL.Types;

namespace CustomCountries.API.GraphqlCore
{
    public class CountrySchema : Schema
    {
        public CountrySchema()
        {
            Query = new CountryQuery();
        }
    }
}
