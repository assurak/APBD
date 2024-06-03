using cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace cw10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductsCategories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductsCategories)
            .HasForeignKey(pc => pc.CategoryId);

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.AccountId, sc.ProductId });

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Account)
            .WithMany(a => a.ShoppingCarts)
            .HasForeignKey(sc => sc.AccountId);

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Product)
            .WithMany(p => p.ShoppingCarts)
            .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.Role)
            .WithMany(r => r.Accounts)
            .HasForeignKey(a => a.RoleId);

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                RoleId = 1,
                Name = "User"
            }
        });

        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                AccountId = 1,
                Email = "j@k.com",
                FirstName = "Jan",
                LastName = "Kowalski",
                Phone = "999888777",
                RoleId = 1

            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                Name = "category1"
            }
        });
        
    }
}