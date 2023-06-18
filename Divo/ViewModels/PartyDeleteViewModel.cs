using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class PartyDetailsViewModel
    {
        public Party Party { get; set; }
        public IEnumerable<PartyMember> PartyMembers { get; set; }
        public  IEnumerable<Participant> Participants { get; set; }
    }
}
