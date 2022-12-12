using CourseCRM.Models;

namespace CourseCRM.Repository
{
    public interface ICourseRepository
    {
        public List<Lead> GetAllLeads();
        public List<Course> GetAllCourse();
        public Lead? GetLead(string email, string cpf);
        public Lead? GetLead(int? id);

        public Lead? GetLeadAndEnrollment(int? id);
        public Lead CreateLeader(Lead lead);
        public void DeleteLeader(Lead lead);
        public void EditLeader(Lead lead);

        public bool LeadExists(int? id);
    }
}
