namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;

public class GetVehicleExitsByVehicleIdDTO
{
    public Guid VehicleId { get; set; }

    public GetVehicleExitsByVehicleIdDTO(Guid vehicleId)
    {
        VehicleId = vehicleId;
    }
}