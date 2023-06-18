using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vidly.Models
{
    public class RoleEdit
    {
        public IdentityUser User { get; set; }
        public IEnumerable<IdentityRole> Members { get; set; }
        public IEnumerable<IdentityRole> NonMembers { get; set; }
    }
}
