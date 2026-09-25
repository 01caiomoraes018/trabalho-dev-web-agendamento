using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public class Paciente : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF.")]
        [StringLength(14)]
        [RegularExpression(@"(\d{11}|\d{3}\.\d{3}\.\d{3}-\d{2})", ErrorMessage = "Use 11 números ou o formato 000.000.000-00.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o telefone.")]
        [StringLength(20)]
        [RegularExpression(@"\(?\d{2}\)? ?\d{4,5}-?\d{4}", ErrorMessage = "Informe o telefone com DDD.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o endereço.")]
        [StringLength(200, ErrorMessage = "O endereço deve ter até 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateOnly? DataNascimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataNascimento.HasValue &&
                (DataNascimento.Value > DateOnly.FromDateTime(DateTime.Today) || DataNascimento.Value.Year < 1900))
            {
                yield return new ValidationResult("Informe uma data entre 01/01/1900 e hoje.",
                    new[] { nameof(DataNascimento) });
            }
        }
    }
}
