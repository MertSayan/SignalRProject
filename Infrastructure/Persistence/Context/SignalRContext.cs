﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SignalRContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SignalRProject;User=TestUser;Password=321321;TrustServerCertificate=true");
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
        public DbSet<MoneyCase> MoneyCases{ get; set; } 
        public DbSet<Table> MenuTables { get; set; }
        public DbSet<Slider> Sliders{ get; set; }
       
    }
}
