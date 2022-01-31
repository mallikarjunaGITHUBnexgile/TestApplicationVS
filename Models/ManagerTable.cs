using System;
using System.Collections.Generic;

namespace TestApplication.Models
{
    public partial class ManagerTable
    {
        public ManagerTable()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int RoleId { get; set; }
        public int ManagerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MailId { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? Zipcode { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
