using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CourseCRM.Models
{
    public class Enrollment
    {

        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public int LeadId { get; set; }
        public Lead Lead { get; set; } = default!;

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Registration { get; set; }
    }
}
