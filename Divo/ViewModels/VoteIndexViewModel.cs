using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Models;

namespace Divo.ViewModels
{
    public class VoteIndexViewModel
    {
        public IEnumerable<Vote> Votes { get; set; }
        public IEnumerable<Voting> Votings { get; set; }


        // delete later
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

    }
}
