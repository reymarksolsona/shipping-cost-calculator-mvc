using Exercise2MVC.Contracts.Services;
using Exercise2MVC.DataAccess.Repository;
using Exercise2MVC.Models.Entities;
using Exercise2MVC.Services;
using System.Web.Mvc;

namespace Exercise2MVC.Controllers
{
    public class ParcelItemController : Controller
    {
        private IParcelItemService _parcelItemService;

        private void InitDependency()
        {
            var repo = new ParcelItemRepository();
            _parcelItemService = new ParcelItemService(repo);
        }

        // GET: ParcelItem
        public ActionResult Index(int? parcelId, int? page)
        {
            if (parcelId == null)
            {
                return RedirectToAction("Index","Customer");
            }

            InitDependency();

            var parcel = _parcelItemService.GetParcelById(parcelId);
            var parcelItems = _parcelItemService.GetPagedParcelItems(parcelId, page);

            TempData["parcelId"] = parcelId;
            TempData["customerId"] = parcel.CustomerID;

            return View(parcelItems);
        }

        // GET: ParcelItem/Create
        public ActionResult Create(int? parcelId)
        {
            if (parcelId == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            ParcelItem parcelItem = new ParcelItem
            {
                Parcel = new Parcel { ParcelID = (int)parcelId },
                ParcelID = (int)parcelId
            };

            return View(parcelItem);
        }

        // POST: ParcelItem/Create
        [HttpPost]
        public ActionResult Create(ParcelItem parcelItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _parcelItemService.AddParcelItem(parcelItem);

                    TempData["SuccessMessage"] = $"Parcel Item added successfully.";

                    return RedirectToAction("Index", new { parcelId = parcelItem.ParcelID });
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            parcelItem = new ParcelItem
            {
                Parcel = new Parcel { ParcelID = parcelItem.ParcelID },
                ParcelID = parcelItem.ParcelID
            };

            return View(parcelItem);
        }

        // GET: ParcelItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            ParcelItem parcel = _parcelItemService.GetParcelItemById(id);

            TempData["customerId"] = parcel.Parcel.CustomerID;

            if (parcel == null)
            {
                TempData["ErrorMessage"] = "Parcel not found.";
                return RedirectToAction("Index");
            }

            return View(parcel);
        }

        // POST: ParcelItem/Edit/5
        [HttpPost]
        public ActionResult Edit(ParcelItem parcelIitem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InitDependency();

                    _parcelItemService.UpdateParcelItem(parcelIitem);

                    TempData["SuccessMessage"] = $"Parcel Item updated successfully.";

                    return RedirectToAction("Index", new { parcelId = parcelIitem.ParcelID });
                }
            }
            catch
            {
                return View("Error", "_Layout");
            }

            return View(parcelIitem);
        }

        // GET: ParcelItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            InitDependency();

            ParcelItem parcelItem = _parcelItemService.GetParcelItemById(id);

            if (parcelItem == null)
            {
                TempData["ErrorMessage"] = "Parcel Item not found.";
                return RedirectToAction("Index");
            }

            return View(parcelItem);
        }

        // POST: ParcelItem/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                InitDependency();

                ParcelItem parcelItem = _parcelItemService.DeleteParcelItem(id);

                TempData["SuccessMessage"] = $"Parcel Item {parcelItem.Title} deleted successfully.";

                return RedirectToAction("Index", new { parcelId = parcelItem.ParcelID });
            }
            catch
            {
                return View("Error", "_Layout");
            }
        }
    }
}