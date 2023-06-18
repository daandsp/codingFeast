using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloxmod.Data.Interfaces
{
    public interface IBloxmodDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void RemoveRange(IEnumerable<object> entities);
    }
}
