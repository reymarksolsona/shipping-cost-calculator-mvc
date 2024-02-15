using Exercise2MVC.Models.Entities;
using PagedList;

namespace Exercise2MVC.Contracts.Services
{
    public interface ICustomerService
    {
        IPagedList<Customer> GetPagedCustomers(int? page);
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int? customerId);
        void UpdateCustomer(Customer customer);
        string DeleteCustomerAndRelatedData(int customerId);
    }
}