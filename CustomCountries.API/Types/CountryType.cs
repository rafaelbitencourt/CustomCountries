using CustomCountries.API.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Types
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType()
        {
            Name = "Country";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Identificação do país");
            Field(x => x.Area).Description("Área do país");
            Field(x => x.Population).Description("População do país");
            Field(x => x.PopulationDensity).Description("A população por quilômetro quadrado");
            Field(x => x.Capital).Description("Capital do país");
        }
        //_id: String
        //area: Float
        //population: Float!
        //populationDensity: Float
        //capital: String!
    }
}
