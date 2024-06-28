using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Persistence;

public interface IVehicleEntryRepository
{
    Task<VehicleEntry?> GetVehicleEntryById(Guid id);
    Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByVehicleId(Guid vehicleId);
    Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByEstablishmentId(Guid establishmentId);
    Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByEstablishmentIdAndVehicleType(Guid establishmentId, string vehicleType);
    Task<VehicleEntry> CreateVehicleEntry(VehicleEntry vehicleEntry);
    Task DeleteVehicleEntry(Guid id);
}