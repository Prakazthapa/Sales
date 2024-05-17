using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class SerialNumber
    {
        [Key]
        public int SerialNumberId { get; set; }

        [Required]

        public int PId { get; set; }

        [ForeignKey(nameof(PId))]
        [ValidateNever]

        public Product? Product { get; set; }

        public int? OId { get; set; }

        [ForeignKey(nameof(OId))]
        [ValidateNever]

        public Order? Order { get; set; }

        [Required]
        public string? Serialno { get; set; }

        [Required]
        [StringLength(1)]
        [ValidateNever]
        public string? stock { get; set; }

    }
}
