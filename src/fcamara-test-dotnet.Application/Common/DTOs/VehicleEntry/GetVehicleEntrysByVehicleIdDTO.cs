namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class GetVehicleEntrysByVehicleIdDTO
{
    public Guid VehicleId { get; set; }

    public GetVehicleEntrysByVehicleIdDTO(Guid vehicleId)
    {
        VehicleId = vehicleId;
    }
}