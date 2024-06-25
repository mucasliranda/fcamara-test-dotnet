using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Contracts.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace fcamara_test_dotnet.Api.Controllers;

[Route("api/vehicles")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly VehicleService _vehicleService;

    public VehicleController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetVehicleResponse>>> Get()
    {
        var vehicles = await _vehicleService.GetVehicles();
        var response = vehicles.Select(v => new GetVehicleResponse(
            v.Id,
            v.Brand,
            v.Model,
            v.Color,
            v.Plate,
            v.Type
        ));

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetVehicleResponse>> Get(Guid id)
    {
        var vehicle = await _vehicleService.GetVehicleById(
            new GetVehicleByIdDTO(id)
        );
        if (vehicle == null)
        {
            return NotFound();
        }

        var response = new GetVehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Color,
            vehicle.Plate,
            vehicle.Type
        );

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateVehicleResponse>> Post([FromBody] CreateVehicleRequest request)
    {
        var vehicle = await _vehicleService.CreateVehicle(
            new CreateVehicleDTO(
                request.Brand,
                request.Model,
                request.Color,
                request.Plate,
                request.Type
            )
        );
        var response = new CreateVehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Color,
            vehicle.Plate,
            vehicle.Type
        );

        return Ok(response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateVehicleResponse>> Patch([FromBody] UpdateVehicleRequest request)
    {
        var vehicle = await _vehicleService.UpdateVehicle(
            new UpdateVehicleDTO(
                request.Id,
                request.Brand,
                request.Model,
                request.Color,
                request.Plate,
                request.Type
            )
        );
        var response = new UpdateVehicleResponse(
            vehicle.Id,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Color,
            vehicle.Plate,
            vehicle.Type
        );

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteVehicleRequest request)
    {
        await _vehicleService.DeleteVehicle(
            new DeleteVehicleDTO(request.Id)
        );

        return Ok();
    }
}