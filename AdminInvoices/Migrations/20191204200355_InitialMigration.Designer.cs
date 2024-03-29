﻿// <auto-generated />
using System;
using AdminInvoices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminInvoices.Migrations
{
    [DbContext(typeof(InvoicesDbContext))]
    [Migration("20191204200355_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AdminInvoices")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdminInvoices.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bob@example.com",
                            FirstName = "Robert",
                            Surname = "Robertson"
                        },
                        new
                        {
                            Id = 2,
                            Email = "betty@example.com",
                            FirstName = "Betty",
                            Surname = "Thornton"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jin@example.com",
                            FirstName = "Jin",
                            Surname = "Marsdon"
                        });
                });

            modelBuilder.Entity("AdminInvoices.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<int>("OrderId");

                    b.Property<int?>("OrderId1");

                    b.Property<bool>("Sent");

                    b.HasKey("Id");

                    b.HasIndex("OrderId1");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CustomerId = -1,
                            OrderId = -1,
                            Sent = false
                        },
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            OrderId = 2,
                            Sent = false
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderId = 2,
                            Sent = true
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            OrderId = 3,
                            Sent = true
                        });
                });

            modelBuilder.Entity("AdminInvoices.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<bool>("Dispatched");

                    b.Property<int?>("InvoiceId");

                    b.Property<bool>("Invoiced");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            Dispatched = false,
                            InvoiceId = -1,
                            Invoiced = false
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Dispatched = false,
                            InvoiceId = 2,
                            Invoiced = true
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Dispatched = true,
                            InvoiceId = 3,
                            Invoiced = true
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 1,
                            Dispatched = false,
                            InvoiceId = 4,
                            Invoiced = true
                        });
                });

            modelBuilder.Entity("AdminInvoices.Invoice", b =>
                {
                    b.HasOne("AdminInvoices.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId1");
                });

            modelBuilder.Entity("AdminInvoices.Order", b =>
                {
                    b.HasOne("AdminInvoices.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
