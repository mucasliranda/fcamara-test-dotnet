using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository ReportRepository)
    {
        _reportRepository = ReportRepository;
    }

    public async Task<EntryAndExitReportResult> GetEstablishmentEntryAndExitReport(Guid id)
    {
        return await _reportRepository.GetEstablishmentEntryAndExitReport(id);
    }

    public async Task<EntryAndExitReportByHourResult> GetEstablishmentEntryAndExitReportByHour(Guid id)
    {
        return await _reportRepository.GetEstablishmentEntryAndExitReportByHour(id);
    }

}