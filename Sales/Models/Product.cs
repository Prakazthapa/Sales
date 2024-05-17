using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [Required]
        [StringLength(450)]
        public string? PName { get; set; }

        [Required]

        public string? PDescription { get; set; }

        [Required]

        public  float price { get; set; }

        
    }
}
