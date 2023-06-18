using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class PartyPartyMembersViewModel
    {
        public Party Party { get; set; }
        public IEnumerable<PartyMember> PartyMembers { get; set; }
    }
}
