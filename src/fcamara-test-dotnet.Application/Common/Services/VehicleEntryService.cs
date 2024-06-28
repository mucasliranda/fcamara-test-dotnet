using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Application.Common.Services;

public class VehicleEntryService : IVehicleEntryService
{
    private readonly IVehicleEntryRepository _vehicleEntryRepository;
    private readonly IVehicleExitRepository _vehicleExitRepository;
    private readonly IEstablishmentRepository _establishmentRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleEntryService(
        IVehicleEntryRepository vehicleEntryRepository,
        IVehicleExitRepository vehicleExitRepository,
        IEstablishmentRepository establishmentRepository,
        IVehicleRepository vehicleRepository
    )
    {
        _vehicleEntryRepository = vehicleEntryRepository;
        _vehicleExitRepository = vehicleExitRepository;
        _establishmentRepository = establishmentRepository;
        _vehicleRepository = vehicleRepository;
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
        bool hasSlotAvailable = await HasSlotAvailable(
            new HasSlotAvailableDTO(createVehicleEntryDTO.EstablishmentId, createVehicleEntryDTO.VehicleId)
        );

        if (!hasSlotAvailable) {
            throw new ValidationException("Sem vaga disponível para o veiculo.");
        }

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

    private async Task<bool> HasSlotAvailable(HasSlotAvailableDTO hasSlotAvailableDTO) {
        var vehicles = await _vehicleRepository.GetVehicles();

        var vehicle = await _vehicleRepository.GetVehicleById(hasSlotAvailableDTO.VehicleId);
        var establishment = await _establishmentRepository.GetEstablishmentById(hasSlotAvailableDTO.EstablishmentId);

        if (_vehicleRepository == null) {
            throw new NotFoundException("Vehicle not instantiated.");
        }

        if (vehicle == null) {
            throw new NotFoundException("Vehicle not found.");
        }

        if (establishment == null) {
            throw new NotFoundException("Establishment not found.");
        }

        var vehicleEntrys = await _vehicleEntryRepository.GetVehicleEntrysByEstablishmentIdAndVehicleType(hasSlotAvailableDTO.EstablishmentId, vehicle.Type);
            
        var vehicleExits = await _vehicleExitRepository.GetVehicleExitsByEstablishmentIdAndVehicleType(hasSlotAvailableDTO.EstablishmentId, vehicle.Type);

        var vehicleEntrysCount = vehicleEntrys.Count();

        var vehicleExitsCount = vehicleExits.Count();

        var establishmentSpots = vehicle.Type == "car" ? establishment.CarSpots : establishment.MotorcycleSpots;

        if (vehicleEntrysCount - vehicleExitsCount >= establishmentSpots) {
            return false;
        }

        return true;
    }
}