using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Application.Common.Services;

public class EstablishmentService : IEstablishmentService
{
    private readonly IEstablishmentRepository _establishmentRepository;

    public EstablishmentService(IEstablishmentRepository establishmentRepository)
    {
        _establishmentRepository = establishmentRepository;
    }

    public async Task<IEnumerable<Establishment>> GetEstablishments()
    {
        return await _establishmentRepository.GetEstablishments();
    }

    public async Task<Establishment?> GetEstablishmentById(GetEstablishmentByIdDTO getEstablishmentByIdDTO)
    {
        var establishment = await _establishmentRepository.GetEstablishmentById(getEstablishmentByIdDTO.Id);

        if (establishment == null)
        {
            throw new NotFoundException("Establishment not found.");
        }

        return establishment;
    }

    public async Task<Establishment> CreateEstablishment(CreateEstablishmentDTO createEstablishmentDTO)
    {
        var establishment = new Establishment(
            createEstablishmentDTO.Name,
            createEstablishmentDTO.CNPJ,
            createEstablishmentDTO.Address,
            createEstablishmentDTO.Phone,
            createEstablishmentDTO.MotorcycleSpots,
            createEstablishmentDTO.CarSpots
        );

        return await _establishmentRepository.CreateEstablishment(establishment);
    }

    public async Task<Establishment> UpdateEstablishment(UpdateEstablishmentDTO updateEstablishmentDTO)
    {
        var establishment = await _establishmentRepository.GetEstablishmentById(updateEstablishmentDTO.Id);

        if (establishment == null)
        {
            throw new NotFoundException("Establishment not found.");
        }

        var updatedEstablishment = new Establishment(
            updateEstablishmentDTO.Name ?? establishment.Name,
            updateEstablishmentDTO.CNPJ ?? establishment.Cnpj,
            updateEstablishmentDTO.Address ?? establishment.Address,
            updateEstablishmentDTO.Phone ?? establishment.Phone,
            updateEstablishmentDTO.MotorcycleSpots ?? establishment.MotorcycleSpots,
            updateEstablishmentDTO.CarSpots ?? establishment.CarSpots,
            establishment.Id
        );

        return await _establishmentRepository.UpdateEstablishment(updatedEstablishment);
    }

    public async Task DeleteEstablishment(DeleteEstablishmentDTO deleteEstablishmentDTO)
    {
        await _establishmentRepository.DeleteEstablishment(deleteEstablishmentDTO.Id);
    }
}
