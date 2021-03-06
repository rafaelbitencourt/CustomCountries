using CustomCountries.API.Models;
using HotChocolate.Types;

namespace CustomCountries.API.Types
{
    public class CountryType : ObjectType<Country>
    {
        protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
        {
            descriptor.Field(x => x.NumericCode).Type<StringType>();
            descriptor.Field(x => x.Area).Type<FloatType>();
            descriptor.Field(x => x.Population).Type<FloatType>();
            descriptor.Field(x => x.PopulationDensity).Type<FloatType>();
            descriptor.Field(x => x.Capital).Type<StringType>();
        }
    }
}
