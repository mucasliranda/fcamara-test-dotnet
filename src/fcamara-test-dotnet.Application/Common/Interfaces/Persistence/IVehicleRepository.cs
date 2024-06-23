using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Persistence;

public interface IVehicleRepository
{
	Task<IEnumerable<Vehicle>> GetVehicles();
	Task<Vehicle?> GetVehicleById(Guid id);
	Task<Vehicle> CreateVehicle(Vehicle vehicle);
	Task<Vehicle> UpdateVehicle(Vehicle vehicle);
	Task DeleteVehicle(Guid id);
	Task DeleteAllVehicles();
}