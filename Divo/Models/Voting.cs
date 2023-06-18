using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Divo.Models
{
    public class Voting
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
        public bool Active { get; set; }

        public bool Finished { get; set; }
    }
}
