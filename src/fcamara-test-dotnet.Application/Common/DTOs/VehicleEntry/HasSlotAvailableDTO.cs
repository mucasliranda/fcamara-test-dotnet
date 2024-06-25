
namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class HasSlotAvailableDTO
{
    public Guid EstablishmentId { get; set; }
    public Guid VehicleId { get; set; }

    public HasSlotAvailableDTO(Guid establishmentId, Guid vehicleId)
    {
        EstablishmentId = establishmentId;
        VehicleId = vehicleId;
    }
}