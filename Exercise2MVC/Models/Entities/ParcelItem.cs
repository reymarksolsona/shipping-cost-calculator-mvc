using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise2MVC.Models.Entities
{
    [Table("ParcelItems")]
    public class ParcelItem
    {
        public int ParcelItemID { get; set; }

        public int ParcelID { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Weight is mandatory")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public decimal Weight { get; set; }

        public virtual Parcel Parcel { get; set; }
    }
}