using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class Customer
    {
        [Key]
        public int CId { get; set; }

        [Required]

        public string? CName { get; set; }



        public int? ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]

        public Province? Province { get; set; }



        public int? DistrictId { get; set; }
        [ForeignKey(nameof(DistrictId))]

        public District? District { get; set; }



        public int? LocalBodyId { get; set; }
        [ForeignKey(nameof(LocalBodyId))]

        public LocalBody? LocalBody { get; set; }

        [Required]
        public int wardno { get; set; }

        [RegularExpression(@"^(\+[0-9]{1,3})?-[0-9]{10}$", ErrorMessage = "Please enter a valid mobile number.")]
        [Required(ErrorMessage = "Mobile number is required.")]
        public string? MobileNumber { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Email address is required.")]
        public string? Email { get; set; }


    }
}
