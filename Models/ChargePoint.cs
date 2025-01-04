using ICTStrypes.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Models
{
    public class ChargePoint
    {
        [Key]
        [StringLength(39)]
        public string ChargePointId { get; set; } // Required, Immutable

        [Required]
        [StringLength(39)]
        [ChargePointStatusValidation]
        public string Status { get; set; } // Available, Blocked, Charging, Removed, Reserved, Unknown

        [StringLength(4)]
        public string FloorLevel { get; set; } // Optional

        [Required]
        public DateTime LastUpdated { get; set; } // Required
    }

}
