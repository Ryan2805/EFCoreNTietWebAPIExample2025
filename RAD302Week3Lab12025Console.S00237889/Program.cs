using System;
using System.Globalization;
using System.Threading;
using Tracker.WebAPIClient;
using RAD302Week3Lab12025CLS00237889;

namespace RAD302Week3Lab12025Console.S00237889
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
            activityName: "Rad302 Week 3 Lab 1", Task: "Testing Console Queries against the DB Model");

            using (var context = new CustomerDbContext())
            {
                var customers = context.Customers.ToList();

                Console.WriteLine("All Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}, Credit Rating: {customer.CreditRating}");
                }
            }
            using (var context = new CustomerDbContext())
            {
                var highCreditCustomers = context.Customers
                                                 .Where(c => c.CreditRating > 400)
                                                 .ToList();

                Console.WriteLine("Customers with Credit Rating greater than 400:");
                foreach (var customer in highCreditCustomers)
                {
                    Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Address: {customer.Address}, Credit Rating: {customer.CreditRating}");
                }
            }
            using (var context = new CustomerDbContext())
            {
                int newId = context.Customers.Max(c => c.ID) + 1; 

                var newCustomer = new Customer
                {
                    ID = newId,
                    Name = "New Customer",
                    Address = "123 New Street, City",
                    CreditRating = 500.00f
                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();

                Console.WriteLine($"New Customer Added: ID {newCustomer.ID}, Name: {newCustomer.Name}, Address: {newCustomer.Address}, Credit Rating: {newCustomer.CreditRating}");
            }


        }
    }
}
