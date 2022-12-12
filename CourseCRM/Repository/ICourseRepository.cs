using CourseCRM.Models;

namespace CourseCRM.Repository
{
    public interface ICourseRepository
    {
        public List<Lead> GetAllLeads();
        public List<Course> GetAllCourse();
        public Lead? GetLead(string email, string cpf);
        public Lead CreateLeader(Lead lead);
    }
}
