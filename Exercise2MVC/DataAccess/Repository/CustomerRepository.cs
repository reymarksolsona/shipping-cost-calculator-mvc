using Exercise2MVC.Contracts.Repository;
using Exercise2MVC.DataAccess.Context;
using Exercise2MVC.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise2MVC.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.ToList();
            }
        }

        public Customer GetCustomerById(int? customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.Include(p => p.Parcels).FirstOrDefault(c => c.CustomerID == customerId);
            }
        }

        public Customer GetCustomerByName(string name)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.Include(p => p.Parcels).FirstOrDefault(c => c.Name.Equals(name));
            }
        }

        public List<Parcel> GetParcelsByCustomerId(int customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Where(x => x.CustomerID == customerId).ToList();
            }
        }

        public List<ParcelItem> GetParcelItemsByParcel(List<int> parcelsIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Where(x => parcelsIds.Contains(x.ParcelID)).ToList();
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteParcels(List<Parcel> parcels)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                if (parcels != null || parcels.Any())
                {
                    context.Parcels.RemoveRange(parcels);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteParcelItems(List<ParcelItem> parcelItems)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                if (parcelItems != null || parcelItems.Any())
                {
                    context.ParcelItems.RemoveRange(parcelItems);
                    context.SaveChanges();
                }
            }
        }
    }
}