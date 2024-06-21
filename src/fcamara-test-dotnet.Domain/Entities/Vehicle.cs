using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; init; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Plate { get; private set; }
    public string Type { get; private set; }
    
    public Vehicle(string brand, string model, string color, string plate, string type)
    {
        if (!IsBrandValid(brand))
        {
            throw new ValidationException("Marca inválida.");
        }
        if (!IsModelValid(model))
        {
            throw new ValidationException("Modelo inválido.");
        }
        if (!IsColorValid(color))
        {
            throw new ValidationException("Cor inválida.");
        }
        if (!IsPlateValid(plate))
        {
            throw new ValidationException("Placa inválida.");
        }
        if (!IsTypeValid(type))
        {
            throw new ValidationException("Tipo inválido.");
        }

        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

    private static bool IsBrandValid(string brand)
    {
        return !string.IsNullOrWhiteSpace(brand);
    }

    private static bool IsModelValid(string model)
    {
        return !string.IsNullOrWhiteSpace(model);
    }

    private static bool IsColorValid(string color)
    {
        return !string.IsNullOrWhiteSpace(color);
    }

    private static bool IsPlateValid(string plate)
    {
        return !string.IsNullOrWhiteSpace(plate);
    }

    private static bool IsTypeValid(string type)
    {
        if (string.IsNullOrWhiteSpace(type)) return false;
        if (type != "car" && type != "motorcycle") return false;
        return true;
    }
}