using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirtualLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }


    }
}
