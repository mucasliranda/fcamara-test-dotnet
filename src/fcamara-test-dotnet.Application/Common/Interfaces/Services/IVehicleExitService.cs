using fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Services;

public interface IVehicleExitService
{
    Task<VehicleExit?> GetVehicleExitById(GetVehicleExitByIdDTO getVehicleExitByIdDTO);
    Task<IEnumerable<VehicleExit>> GetVehicleExitsByVehicleId(GetVehicleExitsByVehicleIdDTO getVehicleExitsByVehicleIdDTO);
    Task<IEnumerable<VehicleExit>> GetVehicleExitsByEstablishmentId(GetVehicleExitsByEstablishmentIdDTO getVehicleExitsByEstablishmentIdDTO);
    Task<VehicleExit> CreateVehicleExit(CreateVehicleExitDTO createVehicleExitDTO);
    Task DeleteVehicleExit(DeleteVehicleExitDTO deleteVehicleExitDTO);
}