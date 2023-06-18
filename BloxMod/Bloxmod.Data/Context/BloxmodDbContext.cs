using Bloxmod.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloxmod.Data.Context
{
    public class BloxmodDbContext : DbContext, IBloxmodDbContext
    {
        public BloxmodDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
