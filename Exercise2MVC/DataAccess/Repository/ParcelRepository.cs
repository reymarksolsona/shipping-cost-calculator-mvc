using Exercise2MVC.Contracts.Repository;
using Exercise2MVC.DataAccess.Context;
using Exercise2MVC.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise2MVC.DataAccess.Repository
{
    public class ParcelRepository : IParcelRepository
    {
        public IEnumerable<Parcel> GetAllParcels()
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).ToList();
            }
        }

        public Parcel GetParcelById(int? parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Include(p => p.ParcelItems).FirstOrDefault(x => x.ParcelID == parcelId);
            }
        }

        public IEnumerable<Parcel> GetParcelByCustomerId(int? customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Include(p => p.ParcelItems).Where(x => x.CustomerID == customerId).ToList();
            }
        }

        public List<ParcelItem> GetParcelItemsByParcel(List<int> parcelIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Where(x => parcelIds.Contains(x.ParcelID)).ToList();
            }
        }

        public void AddParcel(Parcel parcel)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Parcels.Add(parcel);
                context.SaveChanges();
            }
        }

        public void UpdateParcel(Parcel parcel)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Entry(parcel).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteParcel(int parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                Parcel parcel = context.Parcels.Find(parcelId);
                if (parcel != null)
                {
                    context.Parcels.Remove(parcel);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteParcelItems(List<ParcelItem> parcelItems)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {

                if (parcelItems != null || parcelItems.Any())
                {
                    context.ParcelItems.RemoveRange(parcelItems);
                    context.SaveChanges();
                }
            }
        }
    }
}
