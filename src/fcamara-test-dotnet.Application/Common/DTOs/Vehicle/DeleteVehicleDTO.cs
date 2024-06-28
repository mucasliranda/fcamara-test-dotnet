
namespace fcamara_test_dotnet.Application.Common.DTOs.Vehicle;

public class DeleteVehicleDTO
{
    public Guid Id { get; set; }

    public DeleteVehicleDTO(Guid id)
    {
        Id = id;
    }
}
