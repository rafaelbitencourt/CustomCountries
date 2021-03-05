namespace CustomCountries.API.Models
{
    public class Country
    {
        public string Id { get; set; }
        public float Area { get; set; }
        public float Population { get; set; }
        public float PopulationDensity { get; set; }
        public string Capital { get; set; }
    }
}
