using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Services;

public interface IEstablishmentService
{
    Task<IEnumerable<Establishment>> GetEstablishments();
    Task<Establishment?> GetEstablishmentById(GetEstablishmentByIdDTO getEstablishmentByIdDTO);
    Task<Establishment> CreateEstablishment(CreateEstablishmentDTO createEstablishmentDTO);
    Task<Establishment> UpdateEstablishment(UpdateEstablishmentDTO updateEstablishmentDTO);
    Task DeleteEstablishment(DeleteEstablishmentDTO deleteEstablishmentDTO);
}