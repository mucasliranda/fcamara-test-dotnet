using fcamara_test_dotnet.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace fcamara_test_dotnet.Api.Controllers;

[Route("api/report")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("{establishmentId}")]
    public async Task<ActionResult<object>> Get(Guid establishmentId)
    {
        var reports = await _reportService.GetEstablishmentEntryAndExitReport(establishmentId);

        return Ok(reports);
    }

    [HttpGet("hour/{establishmentId}")]
    public async Task<ActionResult<object>> GetByHour(Guid establishmentId)
    {
        var reports = await _reportService.GetEstablishmentEntryAndExitReportByHour(establishmentId);

        return Ok(reports);
    }
}