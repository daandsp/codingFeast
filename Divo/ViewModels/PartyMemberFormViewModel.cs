using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class PartyMemberFormViewModel
    {
        public IEnumerable<Party> Parties { get; set; }
        public PartyMember PartyMember { get; set; }
    }
}
