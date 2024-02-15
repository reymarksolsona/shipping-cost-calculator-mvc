using Exercise2MVC.Contracts.Repository;
using Exercise2MVC.Contracts.Services;
using Exercise2MVC.Models.Entities;
using PagedList;
using System.Collections.Generic;

namespace Exercise2MVC.Services
{
    public class ParcelService : IParcelService
    {
        private IParcelRepository _repository;
        private const int pageSize = 10; // Adjust the value based on requirements

        public ParcelService(IParcelRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<Parcel> GetPagedParcels(int? customerId, int? page)
        {
            int pageNumber = page ?? 1;
            var parcels = _repository.GetParcelByCustomerId(customerId);
            return parcels.ToPagedList(pageNumber, pageSize);
        }

        public void AddParcel(Parcel parcel)
        {
            // Perform validation or use another validation approach
            _repository.AddParcel(parcel);
        }

        public Parcel GetParcelById(int? parcelId)
        {
            return _repository.GetParcelById(parcelId);
        }

        public void UpdateParcel(Parcel parcel)
        {
            // Perform validation or use another validation approach
            _repository.UpdateParcel(parcel);
        }

        public Parcel DeleteParcelAndRelatedData(int parcelId)
        {
            return DeleteParcel(parcelId);
        }

        private Parcel DeleteParcel(int parcelId)
        {
            Parcel parcel = _repository.GetParcelById(parcelId);
            _repository.DeleteParcel(parcelId);

            // Delete Parcel Items associated with the current parcel
            List<ParcelItem> parcelItems = _repository.GetParcelItemsByParcel(new List<int>() { parcel.ParcelID });
            _repository.DeleteParcelItems(parcelItems);

            return parcel;
        }
    }
}
