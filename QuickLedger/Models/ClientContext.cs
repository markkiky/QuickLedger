using Microsoft.EntityFrameworkCore;
using QuickLedger.Models;

namespace QuickLedger.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<QuickLedger.Models.ClientDTO> ClientDTO { get; set; }
    }
}
