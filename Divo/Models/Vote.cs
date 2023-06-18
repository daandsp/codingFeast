using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Divo.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public Voting Voting { get; set; }

        [Display(Name = "Stembus")]
        public int VotingId { get; set; }
        public Party Party { get; set; }

        [Display(Name = "Partij")]
        public int PartyId { get; set; }

        [Display(Name = "Gebruiker ID")]
        [Column(TypeName = "NVARCHAR(450)")]
        public string UserId { get; set; }

    }
}
