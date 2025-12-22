using Microsoft.AspNetCore.Mvc;
using CollegePortal.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CollegePortal.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly Database _database;

        // Dummy data for courses
        private static readonly List<Course> _courses = new List<Course>
        {
            new Course { CourseId = 1, CourseName = "B.Sc.", Description = "Bachelor of Science", Details = "A comprehensive 3-year undergraduate program focusing on scientific principles and research." },
            new Course { CourseId = 2, CourseName = "M.Sc.", Description = "Master of Science", Details = "A 2-year postgraduate program for advanced specialization in a scientific field." },
            new Course { CourseId = 3, CourseName = "BCA", Description = "Bachelor of Computer Applications", Details = "A 3-year undergraduate program focused on computer science and its applications." }
        };

        public ApiController(Database database)
        {
            _database = database;
        }

        [HttpGet("dashboard-stats")]
        public DashboardStats GetDashboardStats()
        {
            // In a real application, you would fetch this data from the database.
            return new DashboardStats
            {
                TotalCourses = _courses.Count,
                TotalEvents = 5,
                TotalAlumni = 1500
            };
        }

        [HttpGet("course-list")]
        public IEnumerable<Course> GetCourseList()
        {
            return _courses;
        }

        [HttpGet("course/{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        [HttpGet("events")]
        public IEnumerable<Event> GetEvents()
        {
            // In a real application, you would fetch this data from the database.
            return new List<Event>
            {
                new Event { EventId = 1, EventName = "Alumni Meet 2024", EventDate = new DateTime(2024, 12, 20), Location = "College Auditorium", Description = "Annual alumni meet." },
                new Event { EventId = 2, EventName = "Tech Seminar", EventDate = new DateTime(2024, 11, 15), Location = "Seminar Hall", Description = "A seminar on emerging technologies." }
            };
        }
    }
}