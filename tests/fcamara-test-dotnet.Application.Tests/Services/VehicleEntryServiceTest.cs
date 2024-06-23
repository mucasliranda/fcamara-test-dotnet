using System.Reflection;
using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Application.Tests.Services;
public class VehicleEntryServiceTest
{
    private readonly VehicleEntryService _vehicleEntryService;
    private readonly IVehicleEntryRepository _vehicleEntryRepository;

    private readonly VehicleService _vehicleService;
    private readonly IVehicleRepository _vehicleRepository;
    
    private readonly EstablishmentService _establishmentService;
    private readonly IEstablishmentRepository _establishmentRepository;

    private Establishment Establishment;
    private Vehicle Vehicle1;
    private Vehicle Vehicle2;

    public VehicleEntryServiceTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();
        var methodName = MethodBase.GetCurrentMethod().Name;
        optionsBuilder.UseInMemoryDatabase(methodName);

        AppDbContext ctx = new(optionsBuilder.Options);
        
        _vehicleEntryRepository = new VehicleEntryRepository(ctx); 
        _vehicleEntryService = new VehicleEntryService(_vehicleEntryRepository);

        _vehicleRepository = new VehicleRepository(ctx);
        _vehicleService = new VehicleService(_vehicleRepository);

        _establishmentRepository = new EstablishmentRepository(ctx);
        _establishmentService = new EstablishmentService(_establishmentRepository);

        InitializeDatabase().Wait();
    }

    private async Task InitializeDatabase()
    {
        Establishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento 1",
                "12345678901234",
                "Rua 1",
                "27997307658",
                10,
                10
            )
        );

        Vehicle1 = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO(
                "Ford",
                "Fiesta",
                "Preto",
                "ABC1234",
                "car"
            )
        );

        Vehicle2 = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO(
                "Yamaha",
                "Moto",
                "Preto",
                "ABC1234",
                "motorcycle"
            )
        );
    }

    [Fact]
    public async Task CanCreateAVehicleEntry()
    {
        var vehicleEntry = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        Assert.NotNull(vehicleEntry);
        Assert.Equal(Vehicle1.Id, vehicleEntry.VehicleId);
        Assert.Equal(Establishment.Id, vehicleEntry.EstablishmentId);
    }

    [Fact]
    public async Task CannotCreateAVehicleEntryWithNotExistingVehicle()
    {
        await Assert.ThrowsAsync<Exception>(() => _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Guid.NewGuid(),
                Establishment.Id,
                DateTime.Now
            )
        ));
    }

    [Fact]
    public async Task CannotCreateAVehicleEntryWithNotExistingEstablishment()
    {
        await Assert.ThrowsAsync<Exception>(() => _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Guid.NewGuid(),
                DateTime.Now
            )
        ));
    }

    [Fact]
    public async Task CanGetVehicleEntryById()
    {
        var vehicleEntry = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var foundVehicleEntry = await _vehicleEntryService.GetVehicleEntryById(
            new GetVehicleEntryByIdDTO(vehicleEntry.Id)
        );

        Assert.NotNull(foundVehicleEntry);
        Assert.Equal(vehicleEntry.Id, foundVehicleEntry.Id);
        Assert.Equal(vehicleEntry.VehicleId, foundVehicleEntry.VehicleId);
        Assert.Equal(vehicleEntry.EstablishmentId, foundVehicleEntry.EstablishmentId);
    }

    [Fact]
    public async Task CannotGetVehicleEntryByIdWithNotExistingId()
    {
        Assert.Null(await _vehicleEntryService.GetVehicleEntryById(
            new GetVehicleEntryByIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanGetVehicleEntrysByVehicleId()
    {
        var vehicleEntry1 = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleEntry2 = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleEntrys = await _vehicleEntryService.GetVehicleEntrysByVehicleId(
            new GetVehicleEntrysByVehicleIdDTO(Vehicle1.Id)
        );

        Assert.Equal(2, vehicleEntrys.Count());
        Assert.Contains(vehicleEntrys, vehicleEntry => vehicleEntry.Id == vehicleEntry1.Id);
        Assert.Contains(vehicleEntrys, vehicleEntry => vehicleEntry.Id == vehicleEntry2.Id);
    }

    [Fact]
    public async Task CannotGetVehicleEntrysByVehicleIdWithNotExistingVehicleId()
    {
        Assert.Empty(await _vehicleEntryService.GetVehicleEntrysByVehicleId(
            new GetVehicleEntrysByVehicleIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanGetVehicleEntrysByEstablishmentId()
    {
        var vehicleEntry1 = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleEntry2 = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle2.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleEntrys = await _vehicleEntryService.GetVehicleEntrysByEstablishmentId(
            new GetVehicleEntrysByEstablishmentIdDTO(Establishment.Id)
        );

        Assert.Equal(2, vehicleEntrys.Count());
        Assert.Contains(vehicleEntrys, vehicleEntry => vehicleEntry.Id == vehicleEntry1.Id);
        Assert.Contains(vehicleEntrys, vehicleEntry => vehicleEntry.Id == vehicleEntry2.Id);
    }

    [Fact]
    public async Task CannotGetVehicleEntrysByEstablishmentIdWithNotExistingEstablishmentId()
    {
        Assert.Empty(await _vehicleEntryService.GetVehicleEntrysByEstablishmentId(
            new GetVehicleEntrysByEstablishmentIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanDeleteVehicleEntry()
    {
        var vehicleEntry = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        await _vehicleEntryService.DeleteVehicleEntry(
            new DeleteVehicleEntryDTO(vehicleEntry.Id)
        );

        Assert.Null(await _vehicleEntryService.GetVehicleEntryById(
            new GetVehicleEntryByIdDTO(vehicleEntry.Id)
        ));
    }
}
