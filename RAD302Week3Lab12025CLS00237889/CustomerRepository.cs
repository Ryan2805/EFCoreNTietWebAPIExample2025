using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CLS00237889
{
    public class CustomerRepository :ICustomer<Customer>, IDisposable
    {
        private readonly CustomerDbContext context;

        public CustomerRepository(CustomerDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            context.AddRange(entities);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return context.Customers.Where(predicate).AsEnumerable();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public Customer Find(int id)
        {
            return context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Remove(Customer entity)
        {
            context.Customers.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            context.Customers.RemoveRange(entities);
        }
        public bool CheckCredit(int customerId, float amount)
        {
            var customer = context.Customers.Find(customerId);
            if (customer != null)
            {
                return amount <= customer.CreditRating;
            }
            return false; 
        }

        public void Dispose()
        {
            context.Dispose();
        }

        
    }

}
