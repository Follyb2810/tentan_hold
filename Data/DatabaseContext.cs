using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Net.NetworkInformation;
using tenant_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace tenant_api.Data
{
    public class DatabaseContext :IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
