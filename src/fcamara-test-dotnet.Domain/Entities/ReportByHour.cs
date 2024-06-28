
namespace fcamara_test_dotnet.Domain.Entities;

public class ReportByHour
{
    public string Date { get; private set; }
    public string Hour { get; private set; }
    public int Count { get; private set; }

    public ReportByHour(string date, string hour, int count)
    {
        Date = date;
        Hour = hour;
        Count = count;
    }
}