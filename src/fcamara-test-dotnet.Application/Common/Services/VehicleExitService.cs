using fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Services;

public class VehicleExitService : IVehicleExitService
{
    private readonly IVehicleExitRepository _vehicleExitRepository;

    public VehicleExitService(IVehicleExitRepository vehicleExitRepository)
    {
        _vehicleExitRepository = vehicleExitRepository;
    }

    public async Task<VehicleExit?> GetVehicleExitById(GetVehicleExitByIdDTO getVehicleExitByIdDTO)
    {
        return await _vehicleExitRepository.GetVehicleExitById(getVehicleExitByIdDTO.Id);
    }

    public async Task<IEnumerable<VehicleExit>> GetVehicleExitsByVehicleId(GetVehicleExitsByVehicleIdDTO getVehicleExitsByVehicleIdDTO)
    {
        return await _vehicleExitRepository.GetVehicleExitsByVehicleId(getVehicleExitsByVehicleIdDTO.VehicleId);
    }

    public async Task<IEnumerable<VehicleExit>> GetVehicleExitsByEstablishmentId(GetVehicleExitsByEstablishmentIdDTO getVehicleExitsByEstablishmentIdDTO)
    {
        return await _vehicleExitRepository.GetVehicleExitsByEstablishmentId(getVehicleExitsByEstablishmentIdDTO.EstablishmentId);
    }

    public async Task<VehicleExit> CreateVehicleExit(CreateVehicleExitDTO createVehicleExitDTO)
    {
        var vehicleExitExit = new VehicleExit(
            createVehicleExitDTO.VehicleId,
            createVehicleExitDTO.EstablishmentId,
            createVehicleExitDTO.Time
        );

        return await _vehicleExitRepository.CreateVehicleExit(vehicleExitExit);
    }

    public async Task DeleteVehicleExit(DeleteVehicleExitDTO deleteVehicleExitDTO)
    {
        await _vehicleExitRepository.DeleteVehicleExit(deleteVehicleExitDTO.Id);
    }
}