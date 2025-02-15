﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tracker.WebAPIClient;


namespace RAD302Week3Lab12025CLS00237889
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CustomerCoreDB";

            optionsBuilder.UseSqlServer(myConnectionString)
                .LogTo(Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information);

            ActivityAPIClient.Track(
                StudentID: "S00237889",
                StudentName: "Ryan Daly",
                activityName: "Rad302 Week 3 Lab 1",
                Task: "Creating Customer DB Schema"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ActivityAPIClient.Track(
                StudentID: "S00237889",
                StudentName: "Ryan Daly",
                activityName: "Rad302 Week 3 Lab 1",
                Task: "Creating customer db schema"
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    ID = 1,
                    Name = "Patricia McKenna",
                    Address = "8 Johnstown Road, Cork",
                    CreditRating = 200.00f
                },
                new Customer
                {
                    ID = 2,
                    Name = "Helen Bennett",
                    Address = "Garden House Crowther Way, Dublin",
                    CreditRating = 400.00f
                },
                new Customer
                {
                    ID = 3,
                    Name = "Yoshi Tanami",
                    Address = "1900 Oak St., Vancouver",
                    CreditRating = 2000.00f
                },
                new Customer
                {
                    ID = 4,
                    Name = "John Steel",
                    Address = "12 Orchestra Terrace, Dublin 20",
                    CreditRating = 800.00f
                },
                new Customer
                {
                    ID = 5,
                    Name = "Catherine Dewey",
                    Address = "Rue Joseph-Bens 532, Brussels",
                    CreditRating = 600.00f
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

