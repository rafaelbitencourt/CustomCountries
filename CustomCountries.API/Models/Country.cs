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
            if (string.IsNullOrWhiteSpace(NumericCode))
                throw new ValidationException("Deve ser informado o código.");

            if (NumericCode.Length > 4)
                throw new ValidationException("Código deve ter no máximo 4 dígitos.");

            if (string.IsNullOrWhiteSpace(Capital))
                throw new ValidationException("Deve ser informado a capital.");

            if (Capital.Length > 100)
                throw new ValidationException("capital deve ter no máximo 100 caracteres.");

            if (Area < 0)
                throw new ValidationException("Área deve ser maior ou igual a zero.");

            if (Population < 0)
                throw new ValidationException("População deve ser maior ou igual a zero.");

            if (PopulationDensity < 0)
                throw new ValidationException("Densidade da população deve ser maior ou igual a zero.");
        }
    }
}
