using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Divo.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public Voting Voting { get; set; }

        [Display(Name = "Stembus")]
        public int VotingId { get; set; }
        public Party Party { get; set; }

        [Display(Name = "Partij")]
        public int PartyId { get; set; }
    }
}
