using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Tests.Entities;

public class VehicleTest
{
    [Fact]
    public void CanCreateVehicle()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string type = "car";

        var vehicle = new Vehicle(brand, model, color, plate, type);

        Assert.NotNull(vehicle);
        Assert.Equal(brand, vehicle.Brand);
        Assert.Equal(model, vehicle.Model);
        Assert.Equal(color, vehicle.Color);
        Assert.Equal(plate, vehicle.Plate);
        Assert.Equal(type, vehicle.Type);
    }

    [Fact]
    public void CannotCreateVehicleWithEmptyBrand()
    {
        string emptyBrand = " ";
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(emptyBrand, model, color, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithNullBrand()
    {
        string nullBrand = null;
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(nullBrand, model, color, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithEmptyModel()
    {
        string brand = "Ford";
        string emptyModel = " ";
        string color = "Preto";
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, emptyModel, color, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithNullModel()
    {
        string brand = "Ford";
        string nullModel = null;
        string color = "Preto";
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, nullModel, color, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithEmptyColor()
    {
        string brand = "Ford";
        string model = "Ka";
        string emptyColor = " ";
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, emptyColor, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithNullColor()
    {
        string brand = "Ford";
        string model = "Ka";
        string nullColor = null;
        string plate = "ABC1234";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, nullColor, plate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithEmptyPlate()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string emptyPlate = " ";
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, color, emptyPlate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithNullPlate()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string nullPlate = null;
        string type = "car";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, color, nullPlate, type));
    }

    [Fact]
    public void CannotCreateVehicleWithInvalidType()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string invalidType = "Bicicleta";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, color, plate, invalidType));
    }

    [Fact]
    public void CanootCreateVehicleWithEmpytType()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string emptyType = " ";

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, color, plate, emptyType));
    }

    [Fact]
    public void CannotCreateVehicleWithNullType()
    {
        string brand = "Ford";
        string model = "Ka";
        string color = "Preto";
        string plate = "ABC1234";
        string type = null;

        var exception = Assert.Throws<ValidationException>(() => new Vehicle(brand, model, color, plate, type));
    }
}