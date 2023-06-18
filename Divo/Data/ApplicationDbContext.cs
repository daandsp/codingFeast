using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Divo.Models;

namespace Divo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Voting> Votings { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<PartyMember> PartyMembers { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
