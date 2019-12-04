using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;



namespace AdminInvoices.Data
{
    public class InvoicesDbContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        private IHostingEnvironment HostEnv { get; }

        public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options,
                               IHostingEnvironment env) : base(options)
        {
            HostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("AdminInvoices");

            builder.Entity<Order>()
                   .HasKey(b => new {b.Id});

            builder.Entity<Customer>()
                   .HasMany(c => c.Orders)
                   .WithOne(b => b.Customer)
                   .HasForeignKey(b => b.CustomerId);

            builder.Entity<Invoice>()
                   .HasOne(e => e.Order)
                   //.HasForeignKey<Invoice>(b => b.OrderId)
                   ;
            


            // seed data for debug / development testing
            if (HostEnv != null && HostEnv.IsDevelopment())
            {
                builder.Entity<Customer>().HasData(
                    new Customer { Id = 1, Surname = "Robertson", FirstName = "Robert", Email = "bob@example.com" },
                    new Customer { Id = 2, Surname = "Thornton", FirstName = "Betty", Email = "betty@example.com" },
                    new Customer { Id = 3, Surname = "Marsdon", FirstName = "Jin", Email = "jin@example.com" }
                );

                builder.Entity<Order>().HasData(
                    new Order { Id = 1, Invoiced = false, Dispatched = false, CustomerId = 2, InvoiceId = -1 },
                    new Order { Id = 2, Invoiced = true, Dispatched = false, CustomerId = 2, InvoiceId = 2 },
                    new Order { Id = 3, Invoiced = true, Dispatched = true, CustomerId = 3, InvoiceId = 3 },
                    new Order { Id = 4, Invoiced = true, Dispatched = false, CustomerId = 1, InvoiceId = 4 }
                 );

                builder.Entity<Invoice>().HasData(
                    new Invoice { Id = -1, OrderId = -1, CustomerId = -1, Sent = false }, 
                    new Invoice { Id = 1, OrderId = 2, CustomerId = 2, Sent = false },
                    new Invoice { Id = 2, OrderId = 2, CustomerId = 2, Sent = true },
                    new Invoice { Id = 3, OrderId = 3, CustomerId = 3, Sent = true }
                 );
            }

        }
    }
}