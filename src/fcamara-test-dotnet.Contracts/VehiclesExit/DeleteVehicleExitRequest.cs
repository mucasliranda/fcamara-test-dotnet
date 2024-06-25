
namespace fcamara_test_dotnet.Contracts.VehiclesExit;

public class DeleteVehicleExitRequest
{
    public Guid Id { get; set; }

    public DeleteVehicleExitRequest(Guid id)
    {
        Id = id;
    }
}