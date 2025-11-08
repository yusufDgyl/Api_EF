using MamiYummy.Models;
using Microsoft.EntityFrameworkCore;

namespace MamiYummy.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YUSUFLAPTOP\\SQLEXPRESS;Database=Web_Api_EF_Core;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
