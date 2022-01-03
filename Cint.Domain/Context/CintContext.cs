using Cint.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Cint.Domain.Context
{
    public class CintContext: DbContext
    {
        public CintContext(DbContextOptions<CintContext> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
