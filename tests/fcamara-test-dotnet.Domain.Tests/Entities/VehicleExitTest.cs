using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Tests.Entities;

public class VehicleExitTest
{
    [Fact]
    public void CanCreateVehicleExit()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.NewGuid();
        DateTime time = DateTime.Now;

        var vehicleExit = new VehicleExit(vehicleId, establishmentId, time);

        Assert.NotNull(vehicleExit);
        Assert.Equal(vehicleId, vehicleExit.VehicleId);
        Assert.Equal(establishmentId, vehicleExit.EstablishmentId);
        Assert.Equal(time, vehicleExit.Time);
    }

    [Fact]
    public void CannotCreateVehicleExitWithInvalidVehicleId()
    {
        Guid vehicleId = Guid.Empty;
        Guid establishmentId = Guid.NewGuid();
        DateTime time = DateTime.Now;

        var exception = Assert.Throws<ValidationException>(() => new VehicleExit(vehicleId, establishmentId, time));
    }

    [Fact]
    public void CannotCreateVehicleExitWithInvalidEstablishmentId()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.Empty;
        DateTime time = DateTime.Now;

        var exception = Assert.Throws<ValidationException>(() => new VehicleExit(vehicleId, establishmentId, time));
    }
}