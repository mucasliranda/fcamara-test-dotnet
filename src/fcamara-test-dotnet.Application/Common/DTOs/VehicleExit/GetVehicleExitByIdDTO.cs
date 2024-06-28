namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;

public class GetVehicleExitByIdDTO
{
    public Guid Id { get; set; }

    public GetVehicleExitByIdDTO(Guid id)
    {
        Id = id;
    }
}