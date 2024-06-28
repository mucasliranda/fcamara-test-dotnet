namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class CreateVehicleEntryDTO
{
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public CreateVehicleEntryDTO(Guid vehicleId, Guid establishmentId, DateTime time)
    {
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }
}
