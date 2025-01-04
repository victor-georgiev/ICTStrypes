using ICTStrypes.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Models
{
    public class Location
    {
        [Key]
        [StringLength(39)]
        public string LocationId { get; set; } // Required, Immutable

        [Required]
        [StringLength(45)]
        [LocationTypeValidation]
        public string Type { get; set; } // Parking, Airport, OnStreet, Unknown

        [StringLength(255)]
        public string Name { get; set; } // Optional Display Name

        [Required]
        [StringLength(45)]
        public string Address { get; set; } // Required

        [Required]
        [StringLength(45)]
        public string City { get; set; } // Required

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; } // Required

        [Required]
        [StringLength(45)]
        public string Country { get; set; } // Required

        public List<ChargePoint> ChargePoints { get; set; } = new List<ChargePoint>(); // Optional

        [Required]
        public DateTime LastUpdated { get; set; } // Required
    }

}
