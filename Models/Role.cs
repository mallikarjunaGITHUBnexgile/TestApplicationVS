using System;
using System.Collections.Generic;

namespace TestApplication.Models
{
    public partial class Role
    {
        public Role()
        {
            ManagerTables = new HashSet<ManagerTable>();
            UserTables = new HashSet<UserTable>();
        }

        public string RoleName { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual ICollection<ManagerTable> ManagerTables { get; set; }
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
