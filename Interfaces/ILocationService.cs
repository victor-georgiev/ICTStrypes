using ICTStrypes.Models;

namespace ICTStrypes.Interfaces
{
    public interface ILocationService
    {
        Task<Location> CreateLocationAsync(LocationRequestModel model);

        Task<Location> PatchLocationAsync(string locationId, PatchLocationRequestModel model);

        Task<Location> GetLocationAsync(string locationId);

        Task<bool> UpsertChargePointsAsync(string locationId, ChargePointRequestModel model);
    }
}
