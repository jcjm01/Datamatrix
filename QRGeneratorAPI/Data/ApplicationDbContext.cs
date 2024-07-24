using Microsoft.EntityFrameworkCore;
using QRGeneratorAPI.Models;

namespace QRGeneratorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Nameplate> Nameplates { get; set; }
    }
}
