using ICTStrypes.DB;
using ICTStrypes.Interfaces;
using ICTStrypes.Models;
using Microsoft.EntityFrameworkCore;

namespace ICTStrypes.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateLocationAsync(LocationRequestModel model)
        {
            // Check if the LocationId already exists
            var existingLocation = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(l => l.LocationId == model.LocationId);
            if (existingLocation != null)
            {
                throw new ArgumentException($"A location with ID '{model.LocationId}' already exists.");
            }

            var location = new Location
            {
                LocationId = model.LocationId,
                Type = model.Type,
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country,
                LastUpdated = model.LastUpdated
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> PatchLocationAsync(string locationId, PatchLocationRequestModel model)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == locationId); //.Include(l => l.ChargePoints)
            if (location == null) return null;

            if (!string.IsNullOrEmpty(model.Type)) location.Type = model.Type;
            if (!string.IsNullOrEmpty(model.Name)) location.Name = model.Name;
            if (!string.IsNullOrEmpty(model.Address)) location.Address = model.Address;
            if (!string.IsNullOrEmpty(model.City)) location.City = model.City;
            if (!string.IsNullOrEmpty(model.PostalCode)) location.PostalCode = model.PostalCode;
            if (!string.IsNullOrEmpty(model.Country)) location.Country = model.Country;
            if (model.LastUpdated.HasValue) location.LastUpdated = model.LastUpdated.Value;

            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetLocationAsync(string locationId)
        {
            return await _context.Locations.Include(l => l.ChargePoints).FirstOrDefaultAsync(l => l.LocationId == locationId);
        }

        public async Task<bool> UpsertChargePointsAsync(string locationId, ChargePointRequestModel model)
        {
            var location = await _context.Locations.Include(l => l.ChargePoints).FirstOrDefaultAsync(l => l.LocationId == locationId);
            if (location == null) return false;

            var existingIds = location.ChargePoints.Select(cp => cp.ChargePointId).ToList();
            var requestIds = model.ChargePoints.Select(cp => cp.ChargePointId).ToList();

            // Update existing or add new chargepoints
            foreach (var chargePoint in model.ChargePoints)
            {
                var existing = location.ChargePoints.FirstOrDefault(cp => cp.ChargePointId == chargePoint.ChargePointId);
                if (existing != null)
                {
                    existing.Status = chargePoint.Status;
                    existing.FloorLevel = chargePoint.FloorLevel;
                    existing.LastUpdated = chargePoint.LastUpdated;
                }
                else
                {
                    // Validate ChargePointId uniqueness
                    if (_context.ChargePoints.Any(x => x.ChargePointId == chargePoint.ChargePointId))
                        throw new ArgumentException($"A charge point with ID '{chargePoint.ChargePointId}' already exists.");

                    location.ChargePoints.Add(new ChargePoint
                    {
                        ChargePointId = chargePoint.ChargePointId,
                        Status = chargePoint.Status,
                        FloorLevel = chargePoint.FloorLevel,
                        LastUpdated = chargePoint.LastUpdated
                    });
                }
            }

            // Mark missing chargepoints as "Removed"
            foreach (var chargePoint in location.ChargePoints.Where(cp => !requestIds.Contains(cp.ChargePointId)))
            {
                chargePoint.Status = "Removed";
                chargePoint.LastUpdated = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
