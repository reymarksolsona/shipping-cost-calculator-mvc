using Exercise2MVC.Models.Entities;
using System.Collections.Generic;

namespace Exercise2MVC.Contracts.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int? customerId);
        Customer GetCustomerByName(string name);
        List<Parcel> GetParcelsByCustomerId(int customerId);
        List<ParcelItem> GetParcelItemsByParcel(List<int> parcelsIds);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void DeleteParcels(List<Parcel> parcels);
        void DeleteParcelItems(List<ParcelItem> parcelItems);
    }
}