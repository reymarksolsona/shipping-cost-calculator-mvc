using Exercise2MVC.Contracts.Services;
using Exercise2MVC.DataAccess.Repository;
using Exercise2MVC.Models.Entities;
using Exercise2MVC.Services;
using System.Web.Mvc;

namespace Exercise2MVC.Controllers
{
    public class ParcelController : Controller
    {
        private IParcelService _parcelService;

        private void InitDependency()
        {
            var repo = new ParcelRepository();
            _parcelService = new ParcelService(repo);
        }

        // GET: Parcel
        public ActionResult Index(int? customerId, int? page)
        {
            if (customerId == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            var parcels = _parcelService.GetPagedParcels(customerId, page);

            TempData["customerId"] = customerId;

            return View(parcels);
        }

        // GET: Parcel/Create
        public ActionResult Create(int? customerId)
        {
            if (customerId == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            return View(new Parcel() { CustomerID = (int)customerId });
        }

        // POST: Parcel/Create
        [HttpPost]
        public ActionResult Create(Parcel parcel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _parcelService.AddParcel(parcel);

                    TempData["SuccessMessage"] = $"Parcel added successfully.";

                    return RedirectToAction("Index", new {customerId = parcel.CustomerID});
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            return View(parcel);
        }

        // GET: Parcel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            Parcel parcel = _parcelService.GetParcelById(id);

            if (parcel == null)
            {
                TempData["ErrorMessage"] = "Parcel not found.";
                return RedirectToAction("Index");
            }

            return View(parcel);
        }

        // POST: Parcel/Edit/5
        [HttpPost]
        public ActionResult Edit(Parcel parcel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _parcelService.UpdateParcel(parcel);

                    TempData["SuccessMessage"] = $"Parcel updated successfully.";

                    return RedirectToAction("Index", new { customerId = parcel.CustomerID} );
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            return View(parcel);
        }

        // GET: Parcel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            Parcel parcel = _parcelService.GetParcelById(id);

            if (parcel == null)
            {
                TempData["ErrorMessage"] = "Parcel not found.";
                return RedirectToAction("Index");
            }

            return View(parcel);
        }

        // POST: Parcel/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                InitDependency();

                Parcel parcel = _parcelService.DeleteParcelAndRelatedData(id);

                TempData["SuccessMessage"] = $"Parce {parcel.Title} deleted successfully.";

                return RedirectToAction("Index", new { customerId = parcel.CustomerID });
            }
            catch
            {
                return View("Error", "_Layout");
            }
        }
    }
}
