using Exercise2MVC.Models.Entities;
using PagedList;
using System.Collections.Generic;

namespace Exercise2MVC.Contracts.Services
{
    public interface IParcelService
    {
        IPagedList<Parcel> GetPagedParcels(int? customerId, int? page);
        void AddParcel(Parcel parcel);
        Parcel GetParcelById(int? parcelId);
        void UpdateParcel(Parcel parcel);
        Parcel DeleteParcelAndRelatedData(int parcelId);
    }
}