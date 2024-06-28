
namespace fcamara_test_dotnet.Application.Common.DTOs.Vehicle;

public class GetVehicleByIdDTO
{
    public Guid Id { get; set; }

    public GetVehicleByIdDTO(Guid id)
    {
        Id = id;
    }
}
