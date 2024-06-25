using fcamara_test_dotnet.Application.Common.DTOs.VehicleExit;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Contracts.VehiclesExit;
using Microsoft.AspNetCore.Mvc;

namespace fcamara_test_dotnet.Api.Controllers;

[Route("api/exit")]
[ApiController]
public class VehicleExitController : ControllerBase
{
    private readonly VehicleExitService _vehicleExitService;

    public VehicleExitController(VehicleExitService vehicleExitService)
    {
        _vehicleExitService = vehicleExitService;
    }

    [HttpGet("{establishmentId}")]
    public async Task<ActionResult<IEnumerable<GetVehicleExitResponse>>> Get(Guid establishmentId)
    {
        var vehicleExits = await _vehicleExitService.GetVehicleExitsByEstablishmentId(
            new GetVehicleExitsByEstablishmentIdDTO(establishmentId)
        );
        var response = vehicleExits.Select(ve => new GetVehicleExitResponse(
            ve.Id,
            ve.VehicleId,
            ve.EstablishmentId,
            ve.Time
        ));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateVehicleExitResponse>> Post([FromBody] CreateVehicleExitRequest request)
    {
        var vehicleExit = await _vehicleExitService.CreateVehicleExit(
            new CreateVehicleExitDTO(
                request.VehicleId,
                request.EstablishmentId,
                request.Time
            )
        );
        var response = new CreateVehicleExitResponse(
            vehicleExit.Id,
            vehicleExit.VehicleId,
            vehicleExit.EstablishmentId,
            vehicleExit.Time
        );

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteVehicleExitRequest request)
    {
        await _vehicleExitService.DeleteVehicleExit(
            new DeleteVehicleExitDTO(request.Id)
        );

        return Ok();
    }
}