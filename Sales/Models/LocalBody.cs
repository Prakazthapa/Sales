using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class LocalBody
    {
        [Key]

        public int Id { get; set; }

        [Required]

        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        [ValidateNever]

        public District? District { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]

        [StringLength(400)]
        public string? NameNp { get; set; }

        [Required]

        public bool IsMunicipality { get; set; }

        [Required]

        public int DisplayOrder {  get; set; }

        [Required]

        public int IMUCode { get; set; }

    }
}
