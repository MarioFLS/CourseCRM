using CourseCRM.Models;

namespace CourseCRM.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourse()
        {
            return _context.Course.ToList();
        }

        public List<Lead> GetAllLeads()
        {
            return _context.Leads.ToList();
        }

        public Lead? GetLead(string email, string cpf)
        {
            Lead? lead = _context.Leads.Where(l => l.Email == email || l.Cpf == cpf).FirstOrDefault();
            return lead;
        }

        public Lead CreateLeader(Lead lead)
        {
            lead.Name = lead.Name.Trim();
            lead.Email = lead.Email.Trim();

            _context.Leads.Add(lead);
            _context.SaveChanges();
            return lead;
        }

    }
}
