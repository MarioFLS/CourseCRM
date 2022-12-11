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
    }
}
