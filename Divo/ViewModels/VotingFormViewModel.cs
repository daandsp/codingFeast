using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class VotingFormViewModel
    {
        public Voting Voting { get; set; }
        public IEnumerable<Party> Parties { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
        public string VotingId { get; set; }
        public int[] AddParticipant { get; set; }
    }
}
