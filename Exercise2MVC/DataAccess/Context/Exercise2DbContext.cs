using Exercise2MVC.Models.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Exercise2MVC.DataAccess.Context
{
    public class Exercise2DbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelItem> ParcelItems { get; set; }

        // Constructor to pass the connection string to the base class
        public Exercise2DbContext() : base(ConfigurationManager.ConnectionStrings["Exercise2ConnectionString"].ConnectionString)
        {
            // You can configure the database initialization strategy here if needed
            Database.SetInitializer(new CreateDatabaseIfNotExists<Exercise2DbContext>());
        }
    }
}