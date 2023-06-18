using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Divo.Models
{
    public class PartyMember
    {
        public int Id { get; set; }
        public Party Party { get; set; }

        [Display(Name = "Partij")]
        public int PartyId { get; set; }

        [Required]
        [MaxLength(70)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Positie")]
        public string Role { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Bio")]
        public string Description { get; set; }
    }
}
