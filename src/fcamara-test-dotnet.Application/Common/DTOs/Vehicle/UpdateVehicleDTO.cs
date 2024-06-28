
namespace fcamara_test_dotnet.Application.Common.DTOs.Vehicle;

public class UpdateVehicleDTO
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Type { get; set; }

    public UpdateVehicleDTO(Guid id, string brand, string model, string color, string plate, string type)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }
}
