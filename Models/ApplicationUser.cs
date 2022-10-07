using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirtualLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
    }
}
