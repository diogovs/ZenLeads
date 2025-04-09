using Microsoft.EntityFrameworkCore;
using ZenLeads.Models;

namespace ZenLeads.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
    }
} 