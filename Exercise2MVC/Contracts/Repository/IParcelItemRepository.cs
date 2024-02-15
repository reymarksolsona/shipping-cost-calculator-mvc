using Exercise2MVC.Models.Entities;
using System.Collections.Generic;

namespace Exercise2MVC.Contracts.Repository
{
    public interface IParcelItemRepository
    {
        IEnumerable<ParcelItem> GetAllParcelItems();
        ParcelItem GetParcelItemById(int? parcelItemId);
        IEnumerable<ParcelItem> GetParcelItemsByParcelId(int? parcelId);
        Parcel GetParcelById(int? parcelId);
        void AddParcelItem(ParcelItem parcelItem);
        void UpdateParcelItem(ParcelItem parcelItem);
        void DeleteParcelItem(int parcelItemId);
    }
}