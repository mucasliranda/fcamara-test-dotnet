
namespace fcamara_test_dotnet.Contracts.VehiclesEntry;

public class CreateVehicleEntryRequest
{
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public CreateVehicleEntryRequest(Guid vehicleId, Guid establishmentId, DateTime time)
    {
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }
}