using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class Order
    {
        [Key]

        public int OId { get; set; }

        [Required]
         public int CId { get; set; }
        [ForeignKey(nameof(CId))]
        [ValidateNever]

        public Customer? Customer { get; set; }

        [Required]
        public int PId { get; set; }
        [ForeignKey(nameof(PId))]
        [ValidateNever]

        public Product? Product { get; set; }

        //[Required]
        //public int SerialNumberId { get; set; }
        //[ForeignKey(nameof(SerialNumberId))]
        //[ValidateNever]

        //public SerialNumber? serialNumber { get; set; }


        [Required]

        public DateOnly ODateTime { get; set; }

        [Required]

        public int Quantity { get; set; }

        [Required]

        public float TotalAmount { get; set; }

    }
}
