namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;

public class CreateVehicleExitDTO
{
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public CreateVehicleExitDTO(Guid vehicleId, Guid establishmentId, DateTime time)
    {
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }
}
