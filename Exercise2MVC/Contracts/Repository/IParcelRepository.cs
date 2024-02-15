using Exercise2MVC.Models.Entities;
using System.Collections.Generic;

namespace Exercise2MVC.Contracts.Repository
{
    public interface IParcelRepository
    {
        IEnumerable<Parcel> GetAllParcels();
        Parcel GetParcelById(int? parcelId);
        IEnumerable<Parcel> GetParcelByCustomerId(int? customerId);
        List<ParcelItem> GetParcelItemsByParcel(List<int> parcelIds);
        void AddParcel(Parcel parcel);
        void UpdateParcel(Parcel parcel);
        void DeleteParcel(int parcelId);
        void DeleteParcelItems(List<ParcelItem> parcelItems);
    }
}