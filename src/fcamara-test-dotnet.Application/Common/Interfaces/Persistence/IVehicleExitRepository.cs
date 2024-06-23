using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Persistence;

public interface IVehicleExitRepository
{
    Task<VehicleExit?> GetVehicleExitById(Guid id);
    Task<IEnumerable<VehicleExit>> GetVehicleExitsByVehicleId(Guid vehicleId);
    Task<IEnumerable<VehicleExit>> GetVehicleExitsByEstablishmentId(Guid establishmentId);
    Task<VehicleExit> CreateVehicleExit(VehicleExit vehicleExit);
    Task DeleteVehicleExit(Guid id);
}