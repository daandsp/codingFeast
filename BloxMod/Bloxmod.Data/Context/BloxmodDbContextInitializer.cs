using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bloxmod.Data.Context
{
    public class BloxmodDbContextInitializer
    {
        private readonly ILogger<BloxmodDbContextInitializer> _logger;
        private readonly BloxmodDbContext _context;

        public BloxmodDbContextInitializer(
            ILogger<BloxmodDbContextInitializer> logger,
            BloxmodDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                    _logger.LogInformation("Database is up to date");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }
    }
}
