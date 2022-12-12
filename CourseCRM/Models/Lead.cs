using CourseCRM.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        // Regex do Email https://regexr.com/3e48o
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,6}$", ErrorMessage = "Digite um email válido")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve ter no mínimo 11 números")]
        [AnnotationValidateCpf(ErrorMessage = "CPF Inválido")]
        public string Cpf { get; set; } = default!;

        [NotMapped]
        public List<Enrollment>? Enrollments { get; set; } = default!;

        public string FormatCpf()
        {
            // Formatação de CPF http://www.codigoexpresso.com.br/Home/Postagem/28
            return Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00");
        }
    }
}
