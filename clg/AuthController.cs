using Microsoft.AspNetCore.Mvc;
using CollegePortal.Models;
using BCrypt.Net;

namespace CollegePortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Database _database;

        public AuthController(Database database)
        {
            _database = database;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_database.UserExists(user.Email, user.MobileNo))
            {
                return Conflict("User with the same email or mobile number already exists.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            // Add logic to save user to the database

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            // Add logic to retrieve user from the database
            // and verify password

            return Ok();
        }
    }
}