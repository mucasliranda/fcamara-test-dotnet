namespace fcamara_test_dotnet.Contracts.VehiclesEntry;

public class GetVehicleEntryResponse
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public GetVehicleEntryResponse(Guid id, Guid vehicleId, Guid establishmentId, DateTime time)
    {
        Id = id;
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }
}