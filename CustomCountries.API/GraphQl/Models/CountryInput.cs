namespace CustomCountries.API.GraphQl.Models
{
    public class CountryInput
    {
        public string NumericCode { get; set; }
        public float Area { get; set; }
        public float Population { get; set; }
        public float PopulationDensity { get; set; }
        public string Capital { get; set; }
    }
}
