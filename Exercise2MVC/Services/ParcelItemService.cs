using Exercise2MVC.Contracts.Repository;
using Exercise2MVC.Contracts.Services;
using Exercise2MVC.Models.Entities;
using PagedList;

namespace Exercise2MVC.Services
{
    public class ParcelItemService : IParcelItemService
    {
        private IParcelItemRepository _repository;
        private const int pageSize = 10; // Adjust the value based on requirements

        public ParcelItemService(IParcelItemRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<ParcelItem> GetPagedParcelItems(int? parcelId, int? page)
        {
            int pageNumber = page ?? 1;
            var parcelItems = _repository.GetParcelItemsByParcelId(parcelId);

            return parcelItems.ToPagedList(pageNumber, pageSize);
        }

        public void AddParcelItem(ParcelItem parcelItem)
        {
            // Perform validation or use another validation approach
            _repository.AddParcelItem(parcelItem);
        }

        public ParcelItem GetParcelItemById(int? parcelItemId)
        {
            return _repository.GetParcelItemById(parcelItemId);
        }

        public Parcel GetParcelById(int? parcelId)
        {
            return _repository.GetParcelById(parcelId);
        }

        public void UpdateParcelItem(ParcelItem parcelItem)
        {
            // Perform validation or use another validation approach
            _repository.UpdateParcelItem(parcelItem);
        }

        public ParcelItem DeleteParcelItem(int parcelItemId)
        {
            ParcelItem parcelItem = _repository.GetParcelItemById(parcelItemId);

            if (parcelItem != null)
            {
                _repository.DeleteParcelItem(parcelItemId);
            }

            return parcelItem;
        }
    }
}