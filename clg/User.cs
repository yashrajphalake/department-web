using System.Collections.Generic;

namespace CollegePortal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string PasswordHash { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}