using System.Reflection;
using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Domain.Exceptions;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Application.Tests.Services;

public class EstablishmentServiceTest
{
    private readonly EstablishmentService _establishmentService;
    private readonly IEstablishmentRepository _establishmentRepository;

    public EstablishmentServiceTest()
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();
        var methodName = MethodBase.GetCurrentMethod().Name;
        optionsBuilder.UseInMemoryDatabase(methodName);

        AppDbContext ctx = new(optionsBuilder.Options);
     
        _establishmentRepository = new EstablishmentRepository(ctx); 
        _establishmentService = new EstablishmentService(_establishmentRepository);
    }

    [Fact]
    public async Task CanCreateAnEstablishment()
    {
        await _establishmentRepository.DeleteAllEstablishments();

        var createdEstablishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        Assert.NotNull(createdEstablishment);
        Assert.Equal("Estabelecimento Teste", createdEstablishment.Name);
        Assert.Equal("12345678901234", createdEstablishment.Cnpj);
        Assert.Equal("Rua Teste, 123", createdEstablishment.Address);
        Assert.Equal("11999999999", createdEstablishment.Phone);
        Assert.Equal(10, createdEstablishment.MotorcycleSpots);
        Assert.Equal(10, createdEstablishment.CarSpots);
    }

    [Fact]
    public async Task CanGetAnArrayOfEstablishments()
    {
        await _establishmentRepository.DeleteAllEstablishments();

        await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );
        await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste2",
                "12345678901232",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        var establishments = await _establishmentService.GetEstablishments();

        Assert.NotNull(establishments);
        Assert.NotEmpty(establishments);
        Assert.Equal(2, establishments.Count());
    }

    [Fact]
    public async Task CanGetAnEstablishmentById()
    {
        var createdEstablishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        var establishment = await _establishmentService.GetEstablishmentById(
            new GetEstablishmentByIdDTO(createdEstablishment.Id)
        );

        Assert.NotNull(establishment);
        Assert.Equal("Estabelecimento Teste", establishment.Name);
        Assert.Equal("12345678901234", establishment.Cnpj);
        Assert.Equal("Rua Teste, 123", establishment.Address);
        Assert.Equal("11999999999", establishment.Phone);
        Assert.Equal(10, establishment.MotorcycleSpots);
        Assert.Equal(10, establishment.CarSpots);
    }

    [Fact]
    public async Task CanUpdateAnEstablishment()
    {
        var createdEstablishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        var updatedEstablishment = await _establishmentService.UpdateEstablishment(
            new UpdateEstablishmentDTO(
                createdEstablishment.Id,
                "Estabelecimento Teste Atualizado",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        Assert.NotNull(updatedEstablishment);
        Assert.Equal("Estabelecimento Teste Atualizado", updatedEstablishment.Name);
        Assert.Equal("12345678901234", updatedEstablishment.Cnpj);
        Assert.Equal("Rua Teste, 123", updatedEstablishment.Address);
        Assert.Equal("11999999999", updatedEstablishment.Phone);
        Assert.Equal(10, updatedEstablishment.MotorcycleSpots);
        Assert.Equal(10, updatedEstablishment.CarSpots);
    }

    [Fact]
    public async Task CanDeleteDeletedEstablishment()
    {
        await _establishmentRepository.DeleteAllEstablishments();

        var createdEstablishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                "Estabelecimento Teste",
                "12345678901234",
                "Rua Teste, 123",
                "11999999999",
                10,
                10
            )
        );

        await _establishmentService.DeleteEstablishment(
            new DeleteEstablishmentDTO(createdEstablishment.Id)
        );

        var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
            _establishmentService.GetEstablishmentById(
                new GetEstablishmentByIdDTO(createdEstablishment.Id)
            )
        );
    }

    [Fact]
    public async Task CannotGetNotCreatedEstablishmentById()
    {
        var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
            _establishmentService.GetEstablishmentById(
                new GetEstablishmentByIdDTO(Guid.NewGuid())
            )
        );

        Assert.Equal("Establishment not found.", exception.Message);
    }

    [Fact]
    public async Task CannotUpdateNotCreatedEstablishment()
    {
        var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
            _establishmentService.UpdateEstablishment(
                new UpdateEstablishmentDTO(
                    Guid.NewGuid(),
                    "Estabelecimento Teste Atualizado",
                    "12345678901234",
                    "Rua Teste, 123",
                    "11999999999",
                    10,
                    10
                )
            )
        );

        Assert.Equal("Establishment not found.", exception.Message);
    }

    [Fact]
    public async Task CannotDeleteNotCreatedEstablishment()
    {
        await _establishmentRepository.DeleteAllEstablishments();
        
        var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
            _establishmentService.DeleteEstablishment(
                new DeleteEstablishmentDTO(Guid.NewGuid())
            )
        );

        Assert.Equal("Establishment not found.", exception.Message);
    }
}