using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class OrderDetails
    {
        [Key]

        public int ODId { get; set; }

        [Required]

        public int OId { get; set; }
        [ForeignKey(nameof(OId))]
        [ValidateNever]

        public Order? Order { get; set; }

        [Required]

        public int PId { get; set; }

        [ForeignKey(nameof(PId))]
        [ValidateNever]

        public Product? Product { get; set; }

        [Required]

        public int CId { get; set; }
        [ForeignKey(nameof(CId))]
        [ValidateNever]

        public Customer? Customer { get; set; }

        [Required]

        public string? PName { get; set; }

        [Required]
        
        public string? CName { get; set; }

        [Required]

        public DateOnly ODate { get; set; }

        [Required]

        public int qantity { get; set; }

        [Required]

        public float price { get; set; }

        [Required]

        public float TotalPrice { get; set; }

    }
}