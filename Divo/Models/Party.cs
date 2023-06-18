using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Divo.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Display(Name = "Actief")]
        public bool Active {get; set;}

    }
}
