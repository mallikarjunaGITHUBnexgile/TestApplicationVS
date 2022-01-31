using System;
using System.Collections.Generic;

namespace TestApplication.Models
{
    public partial class Roles
    {
        public Roles()
        {
            ManagerTable = new HashSet<ManagerTable>();
            UserTable = new HashSet<UserTable>();
        }

        public string RoleName { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<ManagerTable> ManagerTable { get; set; }
        public virtual ICollection<UserTable> UserTable { get; set; }
    }
}
