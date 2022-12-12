using CourseCRM.Models;
using Microsoft.EntityFrameworkCore;

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

        public Lead? GetLead(int? id)
        {

            Lead? lead = _context.Leads.FirstOrDefault(l => l.Id == id);
            return lead;
        }

        public Lead? GetLeadAndEnrollment(int? id)
        {
            List<Enrollment> enrollments = _context.Enrollment.Where(e => e.LeadId == id)
                .Include(e => e.Course)
                .ToList();

            Lead? lead = _context.Leads.FirstOrDefault(l => l.Id == id);

            if (lead != null)
            {
                lead.Enrollments = enrollments;
            }
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

        public void DeleteLeader(Lead lead)
        {
            _context.Leads.Remove(lead);
            _context.SaveChanges();
        }

        public void EditLeader(Lead lead)
        {
            _context.Leads.Update(lead);
            _context.SaveChanges();
        }

        public bool LeadExists(int? id)
        {
            return _context.Leads.Any(l => l.Id == id);
        }
    }
}
