using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class District
    {
        [Key]

        public int Id { get; set; }

        [Required]

        public int ProvinceId { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [ValidateNever]

        public Province? Province { get; set; }

        [Required]
        [StringLength(400)]
        public string? Name { get; set; }

        [Required]
        [StringLength(400)]
        public string? NameNp { get; set; }

        [Required]

        public int DisplayOrder { get; set; }

        [Required]

        public int IMUCode { get; set; }




    }
}
