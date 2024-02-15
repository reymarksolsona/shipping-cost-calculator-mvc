using Exercise2MVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise2MVC.Models.Entities
{
    [Table("Parcels")]
    public class Parcel
    {
        public int ParcelID { get; set; }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        [AppValidator(ErrorMessage = "Title must be unique.")]
        public string Title { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ParcelItem> ParcelItems { get; set; }
    }
}