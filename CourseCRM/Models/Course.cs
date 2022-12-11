using System.ComponentModel.DataAnnotations;

namespace CourseCRM.Models
{
    public class Course
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        public string Name { get; set; } = default!;
    }
}
