using CourseCRM.Models;

namespace CourseCRM.Repository
{
    public interface ICourseRepository
    {
        public List<Lead> GetAllLeads();
        public List<Course> GetAllCourse();
    }
}
