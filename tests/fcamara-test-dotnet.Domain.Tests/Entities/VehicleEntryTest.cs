using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Tests.Entities;

public class VehicleEntryTest
{
    [Fact]
    public void CanCreateVehicleEntry()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.NewGuid();
        DateTime time = DateTime.Now;

        var vehicleEntry = new VehicleEntry(vehicleId, establishmentId, time);

        Assert.NotNull(vehicleEntry);
        Assert.Equal(vehicleId, vehicleEntry.VehicleId);
        Assert.Equal(establishmentId, vehicleEntry.EstablishmentId);
        Assert.Equal(time, vehicleEntry.Time);
    }

    [Fact]
    public void CannotCreateVehicleEntryWithInvalidVehicleId()
    {
        Guid vehicleId = Guid.Empty;
        Guid establishmentId = Guid.NewGuid();
        DateTime time = DateTime.Now;

        var exception = Assert.Throws<ValidationException>(() => new VehicleEntry(vehicleId, establishmentId, time));
    }

    [Fact]
    public void CannotCreateVehicleEntryWithInvalidEstablishmentId()
    {
        Guid vehicleId = Guid.NewGuid();
        Guid establishmentId = Guid.Empty;
        DateTime time = DateTime.Now;

        var exception = Assert.Throws<ValidationException>(() => new VehicleEntry(vehicleId, establishmentId, time));
    }
}