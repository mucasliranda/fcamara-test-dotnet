using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Services;

public class VehicleEntryService : IVehicleEntryService
{
    private readonly IVehicleEntryRepository _vehicleEntryRepository;

    public VehicleEntryService(IVehicleEntryRepository vehicleEntryRepository)
    {
        _vehicleEntryRepository = vehicleEntryRepository;
    }

    public async Task<VehicleEntry?> GetVehicleEntryById(GetVehicleEntryByIdDTO getVehicleEntryByIdDTO)
    {
        return await _vehicleEntryRepository.GetVehicleEntryById(getVehicleEntryByIdDTO.Id);
    }

    public async Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByVehicleId(GetVehicleEntrysByVehicleIdDTO getVehicleEntrysByVehicleIdDTO)
    {
        return await _vehicleEntryRepository.GetVehicleEntrysByVehicleId(getVehicleEntrysByVehicleIdDTO.VehicleId);
    }

    public async Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByEstablishmentId(GetVehicleEntrysByEstablishmentIdDTO getVehicleEntrysByEstablishmentIdDTO)
    {
        return await _vehicleEntryRepository.GetVehicleEntrysByEstablishmentId(getVehicleEntrysByEstablishmentIdDTO.EstablishmentId);
    }

    public async Task<VehicleEntry> CreateVehicleEntry(CreateVehicleEntryDTO createVehicleEntryDTO)
    {
        var vehicleEntryExit = new VehicleEntry(
            createVehicleEntryDTO.VehicleId,
            createVehicleEntryDTO.EstablishmentId,
            createVehicleEntryDTO.Time
        );

        return await _vehicleEntryRepository.CreateVehicleEntry(vehicleEntryExit);
    }

    public async Task DeleteVehicleEntry(DeleteVehicleEntryDTO deleteVehicleEntryDTO)
    {
        await _vehicleEntryRepository.DeleteVehicleEntry(deleteVehicleEntryDTO.Id);
    }
}