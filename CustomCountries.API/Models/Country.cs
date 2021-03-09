using System;

namespace CustomCountries.API.Models
{
    public class Country
    {
        public string NumericCode { get; set; }
        public decimal Area { get; set; }
        public decimal Population { get; set; }
        public decimal PopulationDensity { get; set; }
        public string Capital { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.NumericCode))
                throw new Exception("Deve ser informado o código.");

            if (this.NumericCode.Length > 4)
                throw new Exception("Código deve ter no máximo 4 dígitos.");

            if (string.IsNullOrWhiteSpace(this.Capital))
                throw new Exception("Deve ser informado a capital.");

            if (this.Capital.Length > 100)
                throw new Exception("capital deve ter no máximo 100 caracteres.");

            if (this.Area <= 0)
                throw new Exception("Área deve ser maior que zero.");

            if (this.Population <= 0)
                throw new Exception("População deve ser maior que zero.");

            if (this.PopulationDensity <= 0)
                throw new Exception("Densidade da população deve ser maior que zero.");
        }
    }
}
