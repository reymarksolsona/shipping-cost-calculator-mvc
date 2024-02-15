using Exercise2MVC.Contracts.Repository;
using Exercise2MVC.Contracts.Services;
using Exercise2MVC.Models.Entities;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2MVC.Services
{
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository _repository;
        private const int pageSize = 10; // Adjust the value based on requirements

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<Customer> GetPagedCustomers(int? page)
        {
            List<Customer> customers = _repository.GetCustomers();
            int pageNumber = page ?? 1;
            return customers.ToPagedList(pageNumber, pageSize);
        }

        public void AddCustomer(Customer customer)
        {
            // Perform validation or use another validation approach
            _repository.AddCustomer(customer);
        }

        public Customer GetCustomerById(int? customerId)
        {
            return _repository.GetCustomerById(customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            // Perform validation or use another validation approach
            _repository.UpdateCustomer(customer);
        }

        public string DeleteCustomerAndRelatedData(int customerId)
        {
            return DeleteCustomer(customerId);
        }

        private string DeleteCustomer(int customerId)
        {
            Customer customer = _repository.GetCustomerById(customerId);
            _repository.DeleteCustomer(customerId);

            // Delete Parcels and Parcel Items associated with the current customer
            List<Parcel> parcels = _repository.GetParcelsByCustomerId(customer.CustomerID);
            _repository.DeleteParcels(parcels);

            List<ParcelItem> parcelItems = _repository.GetParcelItemsByParcel(parcels.Select(s => s.ParcelID).ToList());
            _repository.DeleteParcelItems(parcelItems);

            return customer.Name;
        }
    }
}
