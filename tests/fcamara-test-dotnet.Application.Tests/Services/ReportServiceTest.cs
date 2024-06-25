using System.Reflection;
using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Application.Tests.Services;

public class ReportServiceTest
{
    private readonly ReportService _reportService;
    private readonly IReportRepository _reportRepository;


    private readonly VehicleEntryService _vehicleEntryService;
    private readonly IVehicleEntryRepository _vehicleEntryRepository;

    private readonly IVehicleExitRepository _vehicleExitRepository;
    private readonly IVehicleExitService _vehicleExitService;

    private readonly VehicleService _vehicleService;
    private readonly IVehicleRepository _vehicleRepository;
    
    private readonly EstablishmentService _establishmentService;
    private readonly IEstablishmentRepository _establishmentRepository;

    private Establishment establishment;
    private Vehicle vehicle1;

    private Vehicle vehicle2;


    public ReportServiceTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();
        var methodName = MethodBase.GetCurrentMethod().Name;
        optionsBuilder.UseInMemoryDatabase(methodName);

        AppDbContext ctx = new(optionsBuilder.Options);

        _reportRepository = new ReportRepository(ctx);
        _reportService = new ReportService(_reportRepository);


        _vehicleRepository = new VehicleRepository(ctx);
        _vehicleService = new VehicleService(_vehicleRepository);

        _establishmentRepository = new EstablishmentRepository(ctx);
        _establishmentService = new EstablishmentService(_establishmentRepository);

        _vehicleExitRepository = new VehicleExitRepository(ctx);
        _vehicleExitService = new VehicleExitService(_vehicleExitRepository);

        _vehicleEntryRepository = new VehicleEntryRepository(ctx); 
        _vehicleEntryService = new VehicleEntryService(
            _vehicleEntryRepository,
            _vehicleExitRepository,
            _establishmentRepository,
            _vehicleRepository
        );

        InitializeDatabase().Wait();
    }

    private async Task InitializeDatabase()
    {
        establishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento 1",
                "12345678901234",
                "Rua 1",
                "27997307658",
                2,
                2
            )
        );

        vehicle1 = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO(
                "Ford",
                "Fiesta",
                "Preto",
                "ABC1234",
                "car"
            )
        );

        vehicle2 = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO(
                "Ford",
                "Fiesta",
                "Preto",
                "ABC1235",
                "car"
            )
        );

        await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                vehicle1.Id,
                establishment.Id,
                DateTime.Today.AddHours(7)
            )
        );

        await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                vehicle2.Id,
                establishment.Id,
                DateTime.Today.AddHours(8)
            )
        );

        await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                vehicle1.Id,
                establishment.Id,
                DateTime.Today.AddHours(9)
            )
        );

        await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                vehicle2.Id,
                establishment.Id,
                DateTime.Today.AddHours(10)
            )
        );
    }

    [Fact]
    public async Task CanGetEstablishmentEntryAndExitReport()
    {
        var report = await _reportService.GetEstablishmentEntryAndExitReport(establishment.Id);

        Assert.NotNull(report);
        Assert.Equal(2, report.Entries);
        Assert.Equal(2, report.Exits);
    }

    [Fact]
    public async Task CanGetEstablishmentEntryAndExitReportByHour()
    {
        var report = await _reportService.GetEstablishmentEntryAndExitReportByHour(establishment.Id);

        Assert.NotNull(report);
        Assert.Equal(2, report.Entries.Count());
        Assert.Equal(2, report.Exits.Count());

        Assert.Equal(1, report.Entries.Count(e => e.Hour == "07:00"));
        Assert.Equal(1, report.Entries.Count(e => e.Hour == "08:00"));

        Assert.Equal(1, report.Exits.Count(e => e.Hour == "09:00"));
        Assert.Equal(1, report.Exits.Count(e => e.Hour == "10:00"));

        Assert.Equal(2, report.Entries.Count(e => e.Date == DateTime.Today.ToString("dd/MM/yyyy")));
    }
}