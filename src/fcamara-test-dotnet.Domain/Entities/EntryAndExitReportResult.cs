
namespace fcamara_test_dotnet.Domain.Entities;

public class EntryAndExitReportResult
{
    public int Entries { get; private set; }
    public int Exits { get; private set; }

    public EntryAndExitReportResult(int entries, int exits)
    {
        Entries = entries;
        Exits = exits;
    }
}