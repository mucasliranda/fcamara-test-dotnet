namespace fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;

public class GetVehicleEntryByIdDTO
{
    public Guid Id { get; set; }

    public GetVehicleEntryByIdDTO(Guid id)
    {
        Id = id;
    }
}