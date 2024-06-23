using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Services;

public interface IVehicleEntryService
{
    Task<VehicleEntry?> GetVehicleEntryById(GetVehicleEntryByIdDTO getVehicleEntryByIdDTO);
    Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByVehicleId(GetVehicleEntrysByVehicleIdDTO getVehicleEntrysByVehicleIdDTO);
    Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByEstablishmentId(GetVehicleEntrysByEstablishmentIdDTO getVehicleEntrysByEstablishmentIdDTO);
    Task<VehicleEntry> CreateVehicleEntry(CreateVehicleEntryDTO createVehicleEntryDTO);
    Task DeleteVehicleEntry(DeleteVehicleEntryDTO deleteVehicleEntryDTO);
}