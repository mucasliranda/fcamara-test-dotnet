using System.Globalization;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;
using fcamara_test_dotnet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Infrastructure.Persistence;

public class ReportRepository: IReportRepository {
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EntryAndExitReportResult> GetEstablishmentEntryAndExitReport(Guid id)
    {
        var entry = await _context.VehiclesEntry.CountAsync(v => v.EstablishmentId == id);
        var exit = await _context.VehiclesExit.CountAsync(v => v.EstablishmentId == id);

        return new EntryAndExitReportResult(entry, exit);
    }

    public async Task<EntryAndExitReportByHourResult> GetEstablishmentEntryAndExitReportByHour(Guid id)
    {
        var entry = await _context.VehiclesEntry
            .Where(v => v.EstablishmentId == id)
            .ToListAsync();

        var exit = await _context.VehiclesExit
            .Where(v => v.EstablishmentId == id)
            .ToListAsync();

        var entryByDateAndHour = entry
            .GroupBy(v => new { Time = DateTime.ParseExact(v.Time.ToLocalTime().ToString("yyyy-MM-dd HH"), "yyyy-MM-dd HH", CultureInfo.CurrentCulture) })
            .Select(v => new ReportByHour(
                v.Key.Time.ToShortDateString(),
                v.Key.Time.ToShortTimeString(),
                v.Count()
            ));

        var exitByDateAndHour = exit
            .GroupBy(v => new { Time = DateTime.ParseExact(v.Time.ToLocalTime().ToString("yyyy-MM-dd HH"), "yyyy-MM-dd HH", CultureInfo.CurrentCulture) })
            .Select(v => new ReportByHour(
                v.Key.Time.ToShortDateString(),
                v.Key.Time.ToShortTimeString(),
                v.Count()
            ));

        return new EntryAndExitReportByHourResult(entryByDateAndHour, exitByDateAndHour);
    }
}