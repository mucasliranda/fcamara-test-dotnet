using System.Reflection;
using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Application.Tests.Services;
public class VehicleExitServiceTest
{
    private readonly VehicleExitService _vehicleExitService;
    private readonly IVehicleExitRepository _vehicleExitRepository;

    private readonly VehicleService _vehicleService;
    private readonly IVehicleRepository _vehicleRepository;
    
    private readonly EstablishmentService _establishmentService;
    private readonly IEstablishmentRepository _establishmentRepository;

    private Establishment Establishment;
    private Vehicle Vehicle1;
    private Vehicle Vehicle2;

    public VehicleExitServiceTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();
        var methodName = MethodBase.GetCurrentMethod().Name;
        optionsBuilder.UseInMemoryDatabase(methodName);

        AppDbContext ctx = new(optionsBuilder.Options);
        
        _vehicleExitRepository = new VehicleExitRepository(ctx); 
        _vehicleExitService = new VehicleExitService(_vehicleExitRepository);

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
    public async Task CanCreateAVehicleExit()
    {
        var vehicleExit = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        Assert.NotNull(vehicleExit);
        Assert.Equal(Vehicle1.Id, vehicleExit.VehicleId);
        Assert.Equal(Establishment.Id, vehicleExit.EstablishmentId);
    }

    [Fact]
    public async Task CannotCreateAVehicleExitWithNotExistingVehicle()
    {
        await Assert.ThrowsAsync<Exception>(() => _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Guid.NewGuid(),
                Establishment.Id,
                DateTime.Now
            )
        ));
    }

    [Fact]
    public async Task CannotCreateAVehicleExitWithNotExistingEstablishment()
    {
        await Assert.ThrowsAsync<Exception>(() => _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Guid.NewGuid(),
                DateTime.Now
            )
        ));
    }

    [Fact]
    public async Task CanGetVehicleExitById()
    {
        var vehicleExit = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var foundVehicleExit = await _vehicleExitService.GetVehicleExitById(
            new GetVehicleExitByIdDTO(vehicleExit.Id)
        );

        Assert.NotNull(foundVehicleExit);
        Assert.Equal(vehicleExit.Id, foundVehicleExit.Id);
        Assert.Equal(vehicleExit.VehicleId, foundVehicleExit.VehicleId);
        Assert.Equal(vehicleExit.EstablishmentId, foundVehicleExit.EstablishmentId);
    }

    [Fact]
    public async Task CannotGetVehicleExitByIdWithNotExistingId()
    {
        Assert.Null(await _vehicleExitService.GetVehicleExitById(
            new GetVehicleExitByIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanGetVehicleExitsByVehicleId()
    {
        var vehicleExit1 = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleExit2 = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleExits = await _vehicleExitService.GetVehicleExitsByVehicleId(
            new GetVehicleExitsByVehicleIdDTO(Vehicle1.Id)
        );

        Assert.Equal(2, vehicleExits.Count());
        Assert.Contains(vehicleExits, vehicleExit => vehicleExit.Id == vehicleExit1.Id);
        Assert.Contains(vehicleExits, vehicleExit => vehicleExit.Id == vehicleExit2.Id);
    }

    [Fact]
    public async Task CannotGetVehicleExitsByVehicleIdWithNotExistingVehicleId()
    {
        Assert.Empty(await _vehicleExitService.GetVehicleExitsByVehicleId(
            new GetVehicleExitsByVehicleIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanGetVehicleExitsByEstablishmentId()
    {
        var vehicleExit1 = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleExit2 = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle2.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        var vehicleExits = await _vehicleExitService.GetVehicleExitsByEstablishmentId(
            new GetVehicleExitsByEstablishmentIdDTO(Establishment.Id)
        );

        Assert.Equal(2, vehicleExits.Count());
        Assert.Contains(vehicleExits, vehicleExit => vehicleExit.Id == vehicleExit1.Id);
        Assert.Contains(vehicleExits, vehicleExit => vehicleExit.Id == vehicleExit2.Id);
    }

    [Fact]
    public async Task CannotGetVehicleExitsByEstablishmentIdWithNotExistingEstablishmentId()
    {
        Assert.Empty(await _vehicleExitService.GetVehicleExitsByEstablishmentId(
            new GetVehicleExitsByEstablishmentIdDTO(Guid.NewGuid())
        ));
    }

    [Fact]
    public async Task CanDeleteVehicleExit()
    {
        var vehicleExit = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                Vehicle1.Id,
                Establishment.Id,
                DateTime.Now
            )
        );

        await _vehicleExitService.DeleteVehicleExit(
            new DeleteVehicleExitDTO(vehicleExit.Id)
        );

        Assert.Null(await _vehicleExitService.GetVehicleExitById(
            new GetVehicleExitByIdDTO(vehicleExit.Id)
        ));
    }
}
