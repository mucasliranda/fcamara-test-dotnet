using fcamara_test_dotnet.Application.Common.DTOs.VehicleEntry;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Contracts.VehiclesEntry;
using Microsoft.AspNetCore.Mvc;

namespace fcamara_test_dotnet.Api.Controllers;

[Route("api/entry")]
[ApiController]
public class VehicleEntryController : ControllerBase
{
    private readonly VehicleEntryService _vehicleEntryService;

    public VehicleEntryController(VehicleEntryService vehicleEntryService)
    {
        _vehicleEntryService = vehicleEntryService;
    }

    [HttpGet("{establishmentId}")]
    public async Task<ActionResult<IEnumerable<GetVehicleEntryResponse>>> Get(Guid establishmentId)
    {
        var vehicleEntrys = await _vehicleEntryService.GetVehicleEntrysByEstablishmentId(
            new GetVehicleEntrysByEstablishmentIdDTO(establishmentId)
        );
        var response = vehicleEntrys.Select(ve => new GetVehicleEntryResponse(
            ve.Id,
            ve.VehicleId,
            ve.EstablishmentId,
            ve.Time
        ));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateVehicleEntryResponse>> Post([FromBody] CreateVehicleEntryRequest request)
    {
        var vehicleEntry = await _vehicleEntryService.CreateVehicleEntry(
            new CreateVehicleEntryDTO(
                request.VehicleId,
                request.EstablishmentId,
                request.Time
            )
        );
        var response = new CreateVehicleEntryResponse(
            vehicleEntry.Id,
            vehicleEntry.VehicleId,
            vehicleEntry.EstablishmentId,
            vehicleEntry.Time
        );

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteVehicleEntryRequest request)
    {
        await _vehicleEntryService.DeleteVehicleEntry(
            new DeleteVehicleEntryDTO(request.Id)
        );

        return Ok();
    }
}