using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise2MVC.Models.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only numeric characters")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }
    }
}