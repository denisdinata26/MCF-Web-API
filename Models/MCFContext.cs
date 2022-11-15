using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class MCFContext : DbContext
    {
        public MCFContext(DbContextOptions<MCFContext> options) : base(options)
        {
        }

        public DbSet<tr_bpkb>? tr_bpkb { get; set; }
        public DbSet<ms_storage_location>? ms_storage_location { get; set; }
        
    }
}