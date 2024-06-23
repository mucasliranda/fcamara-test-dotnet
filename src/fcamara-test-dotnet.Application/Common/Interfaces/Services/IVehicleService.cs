using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Services;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> GetVehicles();
    Task<Vehicle?> GetVehicleById(GetVehicleByIdDTO getVehicleByIdDTO);
    Task<Vehicle> CreateVehicle(CreateVehicleDTO createVehicleDTO);
    Task<Vehicle> UpdateVehicle(UpdateVehicleDTO updateVehicleDTO);
    Task DeleteVehicle(DeleteVehicleDTO deleteVehicleDTO);
}