using Exercise2MVC.Models.Entities;
using PagedList;

namespace Exercise2MVC.Contracts.Services
{
    public interface IParcelItemService
    {
        IPagedList<ParcelItem> GetPagedParcelItems(int? parcelId, int? page);
        void AddParcelItem(ParcelItem parcelItem);
        ParcelItem GetParcelItemById(int? parcelItemId);
        Parcel GetParcelById(int? parcelId);
        void UpdateParcelItem(ParcelItem parcelItem);
        ParcelItem DeleteParcelItem(int parcelItemId);
    }
}