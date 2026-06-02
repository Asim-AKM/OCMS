using Microsoft.EntityFrameworkCore;
using OCMS.Areas.Users.Models;
using OCMS.Models;
using System.Configuration;

namespace OCMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = ConfigurationManager.ConnectionStrings["DbOCMs_Conn"].ConnectionString;
                optionsBuilder.UseNpgsql(conn);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCreadentials> UserCreadentials { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintResponse> ComplaintResponses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}