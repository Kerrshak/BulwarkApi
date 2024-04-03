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
            entity.HasOne(x => x.Customer)
                .WithMany(y => y.Bookings)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired(true);

            entity.HasOne(x => x.Table)
                .WithMany(y => y.Bookings)
                .HasForeignKey(x => x.TableId)
                .IsRequired(true);

            entity.HasOne(x => x.Customer)
                .WithMany(y => y.Bookings)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired(true);
        });

        //modelBuilder.Entity<Category>(entity =>{ });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasMany(x => x.InterestedCategories)
                .WithMany(y => y.InterestedCustomers)
                .UsingEntity<CustomerInterest>(
                    z => z.HasOne(ci => ci.Category)
                        .WithMany()
                        .HasForeignKey(ci => ci.CategoryId)
                        .HasPrincipalKey(cat => cat.CategoryId),
                    z => z.HasOne(ci => ci.Customer)
                        .WithMany()
                        .HasForeignKey(ci => ci.CustomerId)
                        .HasPrincipalKey(cus => cus.CustomerId));

            entity.HasMany(x => x.WatchedProducts)
                .WithMany(y => y.InterestedCustomers)
                .UsingEntity<WatchList>(
                    z => z.HasOne(wl => wl.Product)
                        .WithMany()
                        .HasForeignKey(wl => wl.ProductId)
                        .HasPrincipalKey(x => x.ProductId),
                    z => z.HasOne(wl => wl.Customer)
                        .WithMany()
                        .HasForeignKey(wl => wl.CustomerId)
                        .HasPrincipalKey(y => y.CustomerId));
        });

        //modelBuilder.Entity<CustomerInterest>(entity =>{ });

        //modelBuilder.Entity<EventDetails>(entity =>{ });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(x => x.Order)
                .WithMany(y => y.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .IsRequired(true);

            entity.HasOne(x => x.Product)
                .WithMany(y => y.OrderedItems)
                .HasForeignKey(x => x.ProductId)
                .IsRequired(true);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(x => x.Customer)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired(true);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(true);
        });

        //modelBuilder.Entity<Promotion>(entity => { });

        //modelBuilder.Entity<Table>(entity => { });

        //modelBuilder.Entity<WatchList>(entity => { });
    }
}
