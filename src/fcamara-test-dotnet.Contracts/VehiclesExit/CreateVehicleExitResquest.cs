
namespace fcamara_test_dotnet.Contracts.VehiclesExit;

public class CreateVehicleExitRequest
{
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public CreateVehicleExitRequest(Guid vehicleId, Guid establishmentId, DateTime time)
    {
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }
}