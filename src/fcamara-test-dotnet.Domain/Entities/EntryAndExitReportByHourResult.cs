
namespace fcamara_test_dotnet.Domain.Entities;

public class EntryAndExitReportByHourResult
{
    public IEnumerable<ReportByHour> Entries { get; private set; }
    public IEnumerable<ReportByHour> Exits { get; private set; }

    public EntryAndExitReportByHourResult(IEnumerable<ReportByHour> entries, IEnumerable<ReportByHour> exits)
    {
        Entries = entries;
        Exits = exits;
    }
}