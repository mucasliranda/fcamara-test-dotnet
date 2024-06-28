using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Services;

public interface IReportService
{
    Task<EntryAndExitReportResult> GetEstablishmentEntryAndExitReport(Guid id);
    Task<EntryAndExitReportByHourResult> GetEstablishmentEntryAndExitReportByHour(Guid id);
}