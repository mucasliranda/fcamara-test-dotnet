
namespace fcamara_test_dotnet.Contracts.Vehicles;

public class CreateVehicleRequest
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Type { get; set; }

    public CreateVehicleRequest(string brand, string model, string color, string plate, string type)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }
}