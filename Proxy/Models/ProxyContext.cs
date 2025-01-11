using Microsoft.EntityFrameworkCore;

namespace Proxy.Models
{
    public class ProxyContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public ProxyContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
