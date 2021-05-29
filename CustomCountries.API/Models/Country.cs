using System.ComponentModel.DataAnnotations;

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
                throw new ValidationException("Deve ser informado o código.");

            if (this.NumericCode.Length > 4)
                throw new ValidationException("Código deve ter no máximo 4 dígitos.");

            if (string.IsNullOrWhiteSpace(this.Capital))
                throw new ValidationException("Deve ser informado a capital.");

            if (this.Capital.Length > 100)
                throw new ValidationException("capital deve ter no máximo 100 caracteres.");

            if (this.Area < 0)
                throw new ValidationException("Área deve ser maior ou igual a zero.");

            if (this.Population < 0)
                throw new ValidationException("População deve ser maior ou igual a zero.");

            if (this.PopulationDensity < 0)
                throw new ValidationException("Densidade da população deve ser maior ou igual a zero.");
        }
    }
}
