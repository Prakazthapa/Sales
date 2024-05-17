using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string? Name { get; set; }

        [Required]
        [StringLength (400)]
        public string? NameNp { get; set; }

        [Required]

        public int IMUCode { get; set; }

    }
}
