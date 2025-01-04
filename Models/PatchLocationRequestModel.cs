using ICTStrypes.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Models
{
    public class PatchLocationRequestModel
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; } //should be removed, bar requirements !!!!

        [StringLength(45)]
        [LocationTypeValidation]
        public string Type { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(45)]
        public string Address { get; set; }

        [StringLength(45)]
        public string City { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(45)]
        public string Country { get; set; }

        public DateTime? LastUpdated { get; set; }
    }

}
