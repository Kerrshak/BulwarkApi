using BulwarkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BulwarkApi.Database;

public class BulwarkDb : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CustomerInterest> CustomerInterests { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EventDetails> Events { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Promotion> Promotion { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<WatchList> WatchLists { get; set; }

    public BulwarkDb(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
        
        });

        modelBuilder.Entity<Category>(entity =>
        {
        
        });

        modelBuilder.Entity<CustomerInterest>(entity =>
        {
        
        });

        modelBuilder.Entity<Customer>(entity =>
        {
        
        });

        modelBuilder.Entity<EventDetails>(entity =>
        {
        
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
        
        });

        modelBuilder.Entity<Order>(entity =>
        {
        
        });

        modelBuilder.Entity<Product>(entity =>
        {
        
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
        
        });

        modelBuilder.Entity<Table>(entity =>
        {
        
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
        
        });

    }
}
