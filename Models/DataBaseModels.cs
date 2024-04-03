using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BulwarkApi.Models
{
    public class Booking
    {
    //[BookingId] INT NOT NULL PRIMARY KEY,
        public int BookingId { get; set; }    
    //[CustomerId] INT NOT NULL,
        public int CustomerId { get; set; }
    //[TableId] INT NOT NULL, 
        public int TableId { get; set; }
    //[BookedFor] DATETIME NOT NULL, 
        public DateTime BookedFor { get; set; }
    //[BookedUntil] DATETIME NOT NULL, 
        public DateTime BookedUntil { get; set; }
    //[NumberOfGuests] INT NOT NULL, 
        public int NumberOfGuests { get; set; }
    //[SpecialRequests] NVARCHAR(MAX) NULL, 
        public string? SpecialRequests { get; set; }
    //[CategoryId] INT NULL
        public int CategoryId { get; set; }

        #region relationships

        public Customer Customer { get; set; } = null!;
        public Table Table { get; set; } = null!;
        public Category Category { get; set; } = null!;

        #endregion
    }

    public class Category
    {
 //   [CategoryId] INT NOT NULL PRIMARY KEY,
        public int CategoryId { get; set; }
 //   [Name] NVARCHAR(50) NOT NULL, 
        public required string Name { get; set; }
 //   [ProductInfo] NVARCHAR(MAX) NULL, 
        public string? ProductInfo { get; set; }
        //   [BookingInfo] NVARCHAR(MAX) NULL, 
        public string? BookingInfo { get; set; }
        //   [EventInfo] NVARCHAR(MAX) NULL,
        public string? EventInfo { get; set; }
        //[MainCategoryId] INT NULL
        public int? MainCategoryId { get; set; }

        #region relationships

        public ICollection<Booking> Bookings { get; } = new List<Booking>();
        public ICollection<Customer> InterestedCustomers { get; } = new List<Customer>();
        public ICollection<CustomerInterest> CustomerInterests { get; } = new List<CustomerInterest>();
        public ICollection<Product> Products { get; } = new List<Product>();

        #endregion
    }

    public class Customer
    {
    //[CustomerId] INT NOT NULL PRIMARY KEY, 
        public int CustomerId { get; set; }
    //[FirstName] NVARCHAR(30) NOT NULL,
        public required string FirstName { get; set; }
    //[LastName] NVARCHAR(30) NOT NULL,
        public required string LastName { get; set; }
    //[ContactNumber] NVARCHAR(15) NOT NULL,
        public required string ContactNumber { get; set; }
    //[Email] NVARCHAR(60) NOT NULL,
        public required string Email { get; set; }
    //[AddressLine1] NVARCHAR(60) NULL, 
        public string? AddressLine1 { get; set; }
    //[AddressLine2] NVARCHAR(60) NULL, 
        public string? AddressLine2 { get; set; }
    //[AddressLine3] NVARCHAR(60) NULL, 
        public string? AddressLine3 { get; set; }
    //[PostCode] NVARCHAR(8) NULL, 
        public string? PostCode { get; set; }
    //[DiscordName] NCHAR(10) NULL
        public string? DiscordName { get; set; }
    //    [EncryptedPassword] NVARCHAR(MAX) NOT NULL
        public string? EncryptedPassword { get; set; }
        public bool IsAdmin { get; set; } = false;

        #region relationships

        public ICollection<Booking> Bookings { get; } = new List<Booking>();
        public ICollection<CustomerInterest> CustomerInterests { get; } = new List<CustomerInterest>();
        public ICollection<Category> InterestedCategories { get; } = new List<Category>();
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Product> WatchedProducts { get; } = new List<Product>();
        public ICollection<WatchList> WatchListItems { get; } = new List<WatchList>();

        #endregion
    }

    public class CustomerInterest
    {
    //[CustomerId] INT NOT NULL, 
        public int CustomerId { get; set; }
    //[CategoryId] INT NOT NULL
        public int CategoryId { get; set; }

        #region relationships

        public Customer Customer { get; set; } = null!;
        public Category Category { get; set; } = null!;
        
        #endregion
    }

    public class EventDetails
    {
    //    	[EventId] INT NOT NULL PRIMARY KEY, 
        public int EventId { get; set; }
    //[Name] NVARCHAR(50) NOT NULL, 
        public required string Name { get; set; }
    //[Description] NVARCHAR(MAX) NULL,
        public string? Description { get; set; }
    //[EventDate] DATETIME NULL, 
        public DateTime? EventDate { get; set; }
    //[FinishesAt] DATETIME NULL,
        public DateTime? FinishesAt { get; set; }
    //[Price] MONEY NULL, 
        public decimal? Price { get; set; }
    //[Capacity] INT NULL 
        public int? Capacity { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? FulfillmentDate { get; set; }
        public decimal UnitPriceAtOrder { get; set; }

        #region relationships

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;

        #endregion
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ContactNumber { get; set; }
        public required string Email { get; set; }
        public required DateTime OrderDate { get; set; }
        public DateTime? FulfillmentDate { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? PostCode { get; set; }
        public decimal TotalAtPurchase { get; set; }
        public bool PaidFor { get; set; }
        public string? TransactionId { get; set; }
        public bool Collection { get; set; }
        public bool VariablePrice { get; set; }
        public bool ConfirmedOrder { get; set; }

        #region relationships

        public Customer? Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

        #endregion
    }

    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public string? ImageUrls { get; set; }
        public bool PreOrder { get; set; }
        public bool ReStock { get; set; }
        public DateTime? NextDueIn { get; set; }
        public string? Serial { get; set; }

        #region relationships

        public required Category Category { get; set; }
        public ICollection<Customer> InterestedCustomers { get; set; } = new List<Customer>();
        public ICollection<OrderItem> OrderedItems { get; set; } = new List<OrderItem>();
        public ICollection<WatchList> WatchListEntries { get; set; } = new List<WatchList>();

        #endregion
    }

    public class Promotion
    {
        public int PromotionId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Image { get; set; }
        public required string UrlRedirect { get; set; }
        public bool Active { get; set; }
        public string? SqlString { get; set; }
        public int? OrderInSlideShow { get; set; }
    }

    public class Table
    {
        public int TableId { get; set; }
        public bool Accessible { get; set; }
        public int Seats { get; set; }
        public string? Position { get; set; }
        public int? ConnectedTableId { get; set; }

        #region relationships

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        #endregion
    }

    public class WatchList
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime AddedToList { get; set; }

        #region relationships

        public Customer Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;

        #endregion
    }
}
