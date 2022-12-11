using System.ComponentModel.DataAnnotations;

namespace CourseCRM.Models
{
    public class Lead
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "O email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLengthAttribute(11, ErrorMessage = "O CPF deve ter exatos 11 números")]
        public string Cpf { get; set; } = default!;
    }
}
