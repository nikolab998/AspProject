using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.DataTransfer
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Posts { get; set; }
        public IEnumerable<int> UserUsesCases { get; set; }
        public IEnumerable<int> Likes { get; set; }
        public IEnumerable<string> Comments { get; set; }
    }
}
