using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Tests.Entities;

public class VehicleEntryExitTest
{
    [Fact]
    public void CanCreateVehicleEntryExit()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.NewGuid();
        DateTime entryTime = DateTime.Now;
        DateTime? exitTime = null;

        var vehicleEntryExit = new VehicleEntryExit(vehicleId, establishmentId, entryTime, exitTime);

        Assert.NotNull(vehicleEntryExit);
        Assert.Equal(vehicleId, vehicleEntryExit.VehicleId);
        Assert.Equal(establishmentId, vehicleEntryExit.EstablishmentId);
        Assert.Equal(entryTime, vehicleEntryExit.EntryTime);
        Assert.Equal(exitTime, vehicleEntryExit.ExitTime);
    }

    [Fact]
    public void CanCreateVehicleEntryExitWithExitTime()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.NewGuid();
        DateTime entryTime = DateTime.Now;
        DateTime exitTime = DateTime.Now.AddHours(1);

        var vehicleEntryExit = new VehicleEntryExit(vehicleId, establishmentId, entryTime, exitTime);

        Assert.NotNull(vehicleEntryExit);
        Assert.Equal(vehicleId, vehicleEntryExit.VehicleId);
        Assert.Equal(establishmentId, vehicleEntryExit.EstablishmentId);
        Assert.Equal(entryTime, vehicleEntryExit.EntryTime);
        Assert.Equal(exitTime, vehicleEntryExit.ExitTime);
    }

    [Fact]
    public void CannotCreateVehicleEntryExitWithInvalidVehicleId()
    {
        Guid vehicleId = Guid.Empty;
        Guid establishmentId = Guid.NewGuid();
        DateTime entryTime = DateTime.Now;
        DateTime? exitTime = null;

        var exception = Assert.Throws<ValidationException>(() => new VehicleEntryExit(vehicleId, establishmentId, entryTime, exitTime));
    }

    [Fact]
    public void CannotCreateVehicleEntryExitWithInvalidEstablishmentId()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.Empty;
        DateTime entryTime = DateTime.Now;
        DateTime? exitTime = null;

        var exception = Assert.Throws<ValidationException>(() => new VehicleEntryExit(vehicleId, establishmentId, entryTime, exitTime));
    }
}