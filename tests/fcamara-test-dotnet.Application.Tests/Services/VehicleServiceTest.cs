using System.Reflection;
using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Domain.Exceptions;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Application.Tests.Services;

public class VehicleServiceTest
{
    private readonly VehicleService _vehicleService;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleServiceTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();
        var methodName = MethodBase.GetCurrentMethod().Name;
        optionsBuilder.UseInMemoryDatabase(methodName);

        AppDbContext ctx = new(optionsBuilder.Options);
     
        _vehicleRepository = new VehicleRepository(ctx); 
        _vehicleService = new VehicleService(_vehicleRepository);
    }

    [Fact]
    public async Task CanCreateAVehicle()
    {

        var createdVehicle = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste", "Modelo Teste", "Cor Teste", "ABC1234", "car")
        );

        Assert.NotNull(createdVehicle);
        Assert.Equal("Marca Teste", createdVehicle.Brand);
        Assert.Equal("Modelo Teste", createdVehicle.Model);
        Assert.Equal("Cor Teste", createdVehicle.Color);
        Assert.Equal("ABC1234", createdVehicle.Plate);
        Assert.Equal("car", createdVehicle.Type);
    }

    [Fact]
    public async Task CannotCreateAVehicleWithInvalidType()
    {
        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await _vehicleService.CreateVehicle(
                new CreateVehicleDTO("Marca Teste", "Modelo Teste", "Cor Teste", "ABC1234", "invalid")
            );
        });
    }

    [Fact]
    public async Task CanGetVehicleById()
    {
        var createdVehicle = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste", "Modelo Teste", "Cor Teste", "ABC1234", "car")
        );

        var vehicle = await _vehicleService.GetVehicleById(
            new GetVehicleByIdDTO(createdVehicle.Id)
        );

        Assert.NotNull(vehicle);
        Assert.Equal("Marca Teste", vehicle.Brand);
        Assert.Equal("Modelo Teste", vehicle.Model);
        Assert.Equal("Cor Teste", vehicle.Color);
        Assert.Equal("ABC1234", vehicle.Plate);
        Assert.Equal("car", vehicle.Type);
    }

    [Fact]
    public async Task CanUpdateVehicle()
    {
        await _vehicleRepository.DeleteAllVehicles();

        var createdVehicle = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste", "Modelo Teste", "Cor Teste", "ABC1234", "car")
        );

        var updatedVehicle = await _vehicleService.UpdateVehicle(
            new UpdateVehicleDTO(createdVehicle.Id, "Marca Atualizada", "Modelo Atualizado", "Cor Atualizada", "ABC1234", "car")
        );

        Assert.NotNull(updatedVehicle);
        Assert.Equal("Marca Atualizada", updatedVehicle.Brand);
        Assert.Equal("Modelo Atualizado", updatedVehicle.Model);
        Assert.Equal("Cor Atualizada", updatedVehicle.Color);
        Assert.Equal("ABC1234", updatedVehicle.Plate);
        Assert.Equal("car", updatedVehicle.Type);
    }

    [Fact]
    public async Task CanGetAnArrayOfVehicles()
    {
        await _vehicleRepository.DeleteAllVehicles();
        
        await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste 1", "Modelo Teste 1", "Cor Teste 1", "ABC1234", "car")
        );

        await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste 2", "Modelo Teste 2", "Cor Teste 2", "ABC1234", "motorcycle")
        );

        var vehicles = await _vehicleService.GetVehicles();

        Assert.NotNull(vehicles);
        Assert.NotEmpty(vehicles);
        Assert.Equal(2, vehicles.Count());
    }

    [Fact]
    public async Task CanDeleteAVehicle()
    {
        await _vehicleRepository.DeleteAllVehicles();

        var createdVehicle = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO("Marca Teste", "Modelo Teste", "Cor Teste", "ABC1234", "car")
        );

        await _vehicleService.DeleteVehicle(
            new DeleteVehicleDTO(createdVehicle.Id)
        );

        var vehicles = await _vehicleService.GetVehicles();

        Assert.NotNull(vehicles);
        Assert.Empty(vehicles);
    }
}