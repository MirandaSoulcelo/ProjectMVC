using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class UsersDTO
    {
        public class Users
    {

        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
    }
}