namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class GetVehicleEntrysByEstablishmentIdDTO
{
    public Guid EstablishmentId { get; set; }

    public GetVehicleEntrysByEstablishmentIdDTO(Guid establishmentId)
    {
        EstablishmentId = establishmentId;
    }
}