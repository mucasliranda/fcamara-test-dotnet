using fcamara_test_dotnet.Application.Common.DTOs.Establishment;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Contracts.Establishments;
using Microsoft.AspNetCore.Mvc;

namespace fcamara_test_dotnet.Api.Controllers;

[Route("api/establishments")]
[ApiController]
public class EstablishmentController : ControllerBase
{
    private readonly EstablishmentService _establishmentService;

    public EstablishmentController(EstablishmentService establishmentService)
    {
        _establishmentService = establishmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetEstablishmentResponse>>> Get()
    {
        var establishments = await _establishmentService.GetEstablishments();
        var response = establishments.Select(e => new GetEstablishmentResponse(
            e.Id,
            e.Name,
            e.Cnpj,
            e.Address,
            e.Phone,
            e.MotorcycleSpots,
            e.CarSpots
        ));

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetEstablishmentResponse>> Get(Guid id)
    {
        var establishment = await _establishmentService.GetEstablishmentById(
            new GetEstablishmentByIdDTO(id)
        );
        if (establishment == null)
        {
            return NotFound();
        }

        var response = new GetEstablishmentResponse(
            establishment.Id,
            establishment.Name,
            establishment.Cnpj,
            establishment.Address,
            establishment.Phone,
            establishment.MotorcycleSpots,
            establishment.CarSpots
        );

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEstablishmentResponse>> Post([FromBody] CreateEstablishmentRequest request)
    {
        var establishment = await _establishmentService.CreateEstablishment(
            new CreateEstablishmentDTO(
                request.Name, 
                request.CNPJ, 
                request.Address, 
                request.Phone, 
                request.MotorcycleSpots, 
                request.CarSpots
            )
        );
        var response = new CreateEstablishmentResponse(
            establishment.Id,
            establishment.Name,
            establishment.Cnpj,
            establishment.Address,
            establishment.Phone,
            establishment.MotorcycleSpots,
            establishment.CarSpots
        );

        return Ok(response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateEstablishmentResponse>> Patch([FromBody] UpdateEstablishmentRequest request)
    {
        var establishment = await _establishmentService.UpdateEstablishment(
            new UpdateEstablishmentDTO(
                request.Id,
                request.Name,
                request.CNPJ,
                request.Address,
                request.Phone,
                request.MotorcycleSpots,
                request.CarSpots
            )
        );

        var response = new UpdateEstablishmentResponse(
            establishment.Id,
            establishment.Name,
            establishment.Cnpj,
            establishment.Address,
            establishment.Phone,
            establishment.MotorcycleSpots,
            establishment.CarSpots
        );

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteEstablishmentRequest request)
    {
        await _establishmentService.DeleteEstablishment(
            new DeleteEstablishmentDTO(request.Id)
        );
        
        return Ok();
    }
}