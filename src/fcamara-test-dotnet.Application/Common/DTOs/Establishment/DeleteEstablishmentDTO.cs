
namespace fcamara_test_dotnet.Application.Common.DTOs.Establishment;

public class DeleteEstablishmentDTO
{
    public Guid Id { get; set; }

    public DeleteEstablishmentDTO(Guid id)
    {
        Id = id;
    }
}