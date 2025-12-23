
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

namespace YCISAlumni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Dummy database for demonstration
        private static readonly Dictionary<string, string> users = new Dictionary<string, string>();

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserCredentials credentials)
        {
            if (users.ContainsKey(credentials.Email))
            {
                return Conflict("User already exists.");
            }

            // Hash the password
            var hashedPassword = HashPassword(credentials.Password);
            users.Add(credentials.Email, hashedPassword);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials credentials)
        {
            if (!users.ContainsKey(credentials.Email))
            {
                return Unauthorized("Invalid credentials.");
            }

            var hashedPassword = users[credentials.Email];
            if (!VerifyPassword(credentials.Password, hashedPassword))
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }

    public class UserCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
