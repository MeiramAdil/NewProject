using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewProject.Models;

namespace NewProject.Data
{
  public class MobileContext : IdentityDbContext<AppplicationUser>
  {
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public MobileContext(DbContextOptions<MobileContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

  }
}
