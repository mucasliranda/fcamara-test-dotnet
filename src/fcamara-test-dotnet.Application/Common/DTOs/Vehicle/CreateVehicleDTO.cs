
namespace fcamara_test_dotnet.Application.Common.DTOs.Vehicle;

public class CreateVehicleDTO
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Type { get; set; }

    public CreateVehicleDTO(string brand, string model, string color, string plate, string type)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }
}
