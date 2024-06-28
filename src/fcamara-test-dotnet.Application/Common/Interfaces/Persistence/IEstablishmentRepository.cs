using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Persistence;

public interface IEstablishmentRepository
{
    Task<IEnumerable<Establishment>> GetEstablishments();
    Task<Establishment?> GetEstablishmentById(Guid id);
    Task<Establishment> CreateEstablishment(Establishment establishment);
    Task<Establishment> UpdateEstablishment(Establishment establishment);
    Task DeleteEstablishment(Guid id);
    Task DeleteAllEstablishments();
}