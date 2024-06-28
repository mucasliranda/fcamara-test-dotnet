namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;

public class GetVehicleExitsByEstablishmentIdDTO
{
    public Guid EstablishmentId { get; set; }

    public GetVehicleExitsByEstablishmentIdDTO(Guid establishmentId)
    {
        EstablishmentId = establishmentId;
    }
}