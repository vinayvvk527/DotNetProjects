using System;
using System.Collections.Generic;

namespace EKart.Models
{
    public partial class UserRegistration
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Contact { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
