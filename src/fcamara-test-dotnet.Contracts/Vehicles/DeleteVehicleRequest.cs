
namespace fcamara_test_dotnet.Contracts.Vehicles;

public class DeleteVehicleRequest
{
    public Guid Id { get; set; }

    public DeleteVehicleRequest(Guid id)
    {
        Id = id;
    }
}