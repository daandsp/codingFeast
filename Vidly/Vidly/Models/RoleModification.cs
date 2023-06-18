using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class RoleModification
    {
        public string UserId { get; set; }

        public string[] AddRole { get; set; }

        public string[] DeleteRole { get; set; }
    }
}
