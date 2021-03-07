namespace CustomCountries.API.Models
{
    public class Country
    {
        public string NumericCode { get; set; }
        public decimal Area { get; set; }
        public decimal Population { get; set; }
        public decimal PopulationDensity { get; set; }
        public string Capital { get; set; }
    }
}
