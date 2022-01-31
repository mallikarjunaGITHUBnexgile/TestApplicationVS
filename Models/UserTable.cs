using System;
using System.Collections.Generic;

namespace TestApplication.Models
{
    public partial class UserTable
    {
        public int RoleId { get; set; }
        public int ManagerId { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string MailId { get; set; } = null!;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? Zipcode { get; set; }

        public virtual ManagerTable Manager { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
