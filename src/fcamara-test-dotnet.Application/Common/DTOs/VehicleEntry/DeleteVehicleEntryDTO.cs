namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class DeleteVehicleEntryDTO
{
    public Guid Id { get; set; }

    public DeleteVehicleEntryDTO(Guid id)
    {
        Id = id;
    }
}