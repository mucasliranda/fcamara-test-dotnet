
namespace fcamara_test_dotnet.Contracts.VehiclesEntry;

public class DeleteVehicleEntryRequest
{
    public Guid Id { get; set; }

    public DeleteVehicleEntryRequest(Guid id)
    {
        Id = id;
    }
}