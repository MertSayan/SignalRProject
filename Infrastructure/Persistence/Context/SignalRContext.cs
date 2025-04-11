using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SignalRContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=;User=;Password=;TrustServerCertificate=True");
            //buraya kendi veritabanı bağlantı bilgilerinizi yazacaksınız.
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<Table> MenuTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
//using Domain;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Persistence.Context
//{
//	public class SignalRContext : IdentityDbContext<AppUser, AppRole, int>
//	{
//		// Parametreli constructor ekleyin
//		public SignalRContext(DbContextOptions<SignalRContext> options) : base(options)
//		{
//		}

//		// DbSet'ler
//		public DbSet<About> Abouts { get; set; }
//		public DbSet<Booking> Bookings { get; set; }
//		public DbSet<Category> Categories { get; set; }
//		public DbSet<Contact> Contacts { get; set; }
//		public DbSet<Discount> Discounts { get; set; }
//		public DbSet<Feature> Features { get; set; }
//		public DbSet<Product> Products { get; set; }
//		public DbSet<SocialMedia> SocialMedias { get; set; }
//		public DbSet<Testimonial> Testimonials { get; set; }
//		public DbSet<Order> Orders { get; set; }
//		public DbSet<OrderDetail> OrderDetails { get; set; }
//		public DbSet<MoneyCase> MoneyCases { get; set; }
//		public DbSet<Table> MenuTables { get; set; }
//		public DbSet<Slider> Sliders { get; set; }
//		public DbSet<Basket> Baskets { get; set; }
//		public DbSet<Notification> Notifications { get; set; }
//		public DbSet<Message> Messages { get; set; }
//	}
//}
