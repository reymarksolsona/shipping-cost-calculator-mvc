using Exercise2MVC.Contracts.Services;
using Exercise2MVC.DataAccess.Repository;
using Exercise2MVC.Models.Entities;
using Exercise2MVC.Services;
using System.Web.Mvc;

namespace Exercise2MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        private void InitDependency()
        {
            var repo = new CustomerRepository();
            _customerService = new CustomerService(repo);
        }

        public ActionResult Index(int? page)
        {
            InitDependency();

            var customers = _customerService.GetPagedCustomers(page);

            return View(customers);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _customerService.AddCustomer(customer);

                    TempData["SuccessMessage"] = $"Customer {customer.Name} added successfully.";

                    return RedirectToAction("Index", new { page = 1 });
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            return View(customer);
        }

        //// GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            Customer customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                TempData["ErrorMessage"] = "Customer not found.";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //// POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _customerService.UpdateCustomer(customer);

                    TempData["SuccessMessage"] = $"Customer {customer.Name} updated successfully.";

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            return View(customer);
        }

        //// GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            Customer customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                TempData["ErrorMessage"] = "Customer not found.";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //// POST: Customer/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                InitDependency();

                var customer = _customerService.DeleteCustomerAndRelatedData(id);

                TempData["SuccessMessage"] = $"Customer {customer} deleted successfully.";

                return RedirectToAction("Index", new { page = 1 });
            }
            catch
            {
                return View("Error", "_Layout");
            }
        }
    }
}