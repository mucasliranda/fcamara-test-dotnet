
namespace fcamara_test_dotnet.Application.Common.DTOs.Establishment;

public class GetEstablishmentByIdDTO
{
    public Guid Id { get; set; }

    public GetEstablishmentByIdDTO(Guid id)
    {
        Id = id;
    }
}