using MySql.Data.MySqlClient;
using Dapper;
using CollegePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace CollegePortal
{
    public class Database
    {
        private readonly string _connectionString = "Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";

        public bool UserExists(string email, string mobileNo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var user = connection.QueryFirstOrDefault("SELECT * FROM Users WHERE Email = @Email OR MobileNo = @MobileNo", new { Email = email, MobileNo = mobileNo });
                return user != null;
            }
        }

        public User GetUserWithCourses(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = @"
                    SELECT u.*, c.*
                    FROM Users u
                    LEFT JOIN UserCourses uc ON u.Id = uc.UserId
                    LEFT JOIN Courses c ON uc.CourseId = c.CourseId
                    WHERE u.Id = @UserId;
                ";

                var userDictionary = new Dictionary<int, User>();

                var user = connection.Query<User, Course, User>(
                    sql,
                    (u, c) =>
                    {
                        if (!userDictionary.TryGetValue(u.Id, out var currentUser))
                        {
                            currentUser = u;
                            userDictionary.Add(currentUser.Id, currentUser);
                        }
                        if (c != null)
                        {
                            currentUser.Courses.Add(c);
                        }
                        return currentUser;
                    },
                    new { UserId = userId },
                    splitOn: "CourseId"
                ).FirstOrDefault();

                return user;
            }
        }
    }
}