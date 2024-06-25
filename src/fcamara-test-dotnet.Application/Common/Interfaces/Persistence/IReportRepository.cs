using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Application.Common.Interfaces.Persistence;

public interface IReportRepository
{
    Task<EntryAndExitReportResult> GetEstablishmentEntryAndExitReport(Guid id);
    Task<EntryAndExitReportByHourResult> GetEstablishmentEntryAndExitReportByHour(Guid id);
}