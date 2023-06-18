using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class PartyParticipatingViewModel
    {
        public Party Party { get; set; }
        public IEnumerable<Voting> Votings { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
    }
}
