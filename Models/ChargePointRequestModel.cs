using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Models
{
    public class ChargePointRequestModel
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; } //no need for this, we have it in the url param, should be removed, bad requirements?

        public List<ChargePoint> ChargePoints { get; set; } = new List<ChargePoint>();
    }

}
