using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Primitives;

namespace TM.Domain.Entities
{
    public class User
    {
        public User(UserId userId)
        {
            Id = userId;
        }

        public UserId Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public record UserId(Guid Id);
}
