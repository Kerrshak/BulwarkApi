using System.ComponentModel;

namespace BulwarkApi.Models
{
    public class Booking
    {
    //[BookingId] INT NOT NULL PRIMARY KEY,
        public int BookingId { get; set; }    
    //[CustomerId] INT NOT NULL,
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
    //[TableId] INT NOT NULL, 
        public int TableId { get; set; }
        public required Table Table { get; set; }
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
        public required Category Category { get; set; }
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
        public required List<Booking> Bookings { get; set; }
        public required List<CustomerInterest> CustomerInterests { get; set; }
        public required List<Product> Products { get; set; }
    }

    public class CustomerInterest
    {
    //    [CustomerInterestId] INT NOT NULL PRIMARY KEY,
        public int CustomerInterestId { get; set; }
    //[CustomerId] INT NOT NULL, 
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
    //[CategoryId] INT NOT NULL
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
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

        public required List<Booking> Bookings { get; set; }
        public required List<CustomerInterest> CustomerInterests { get; set; }
        public required List<Order> Orders { get; set; }
        public required List<WatchList> WatchListItems { get; set; }
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
        public required Order Order { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime? FulfillmentDate { get; set; }
        public decimal UnitPriceAtOrder { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
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
        public required List<OrderItem> OrderItems { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrls { get; set; }
        public bool PreOrder { get; set; }
        public bool ReStock { get; set; }
        public DateTime? NextDueIn { get; set; }
        public string? Serial { get; set; }
        public required List<OrderItem> OrderedItems { get; set; }
        public required List<WatchList> WatchListEntries { get; set; }
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
        public int? EventId { get; set; }
        public EventDetails? Event { get; set; }
    }

    public class Table
    {
        public int TableId { get; set; }
        public bool Accessible { get; set; }
        public int Seats { get; set; }
        public string? Position { get; set; }
        public int? ConnectedTableId { get; set; }
        public required List<Booking> Bookings { get; set; }
    }

    public class WatchList
    {
        public int WatchListId { get; set;}
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public DateTime AddedToList { get; set; }
    }
}
