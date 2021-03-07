using CustomCountries.API.Models;
using HotChocolate.Types;

namespace CustomCountries.API.GraphQl.Types
{
    public class CountryType : InputObjectType<Country>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Country> descriptor)
        {
            descriptor.Field(x => x.NumericCode).Type<StringType>();
            descriptor.Field(x => x.Area).Type<DecimalType>();
            descriptor.Field(x => x.Population).Type<DecimalType>();
            descriptor.Field(x => x.PopulationDensity).Type<DecimalType>();
            descriptor.Field(x => x.Capital).Type<StringType>();
        }
    }
}
