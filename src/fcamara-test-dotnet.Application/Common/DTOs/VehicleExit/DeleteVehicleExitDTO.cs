namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;

public class DeleteVehicleExitDTO
{
    public Guid Id { get; set; }

    public DeleteVehicleExitDTO(Guid id)
    {
        Id = id;
    }
}