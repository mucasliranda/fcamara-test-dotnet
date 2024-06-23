using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class VehicleEntryRepository: IVehicleEntryRepository {
    private readonly AppDbContext _context;

    public VehicleEntryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VehicleEntry?> GetVehicleEntryById(Guid id)
    {
        return await _context.VehiclesEntry.FindAsync(id);
    }

    public async Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByVehicleId(Guid vehicleId)
    {
        return await _context.VehiclesEntry.Where(vehicleEntry => vehicleEntry.VehicleId == vehicleId).ToListAsync();
    }

    public async Task<IEnumerable<VehicleEntry>> GetVehicleEntrysByEstablishmentId(Guid establishmentId)
    {
        return await _context.VehiclesEntry.Where(vehicleEntry => vehicleEntry.EstablishmentId == establishmentId).ToListAsync();
    }

    public async Task<VehicleEntry> CreateVehicleEntry(VehicleEntry vehicleEntry)
    {
        var vehicle = await _context.Vehicles.FindAsync(vehicleEntry.VehicleId);
        var establishment = await _context.Establishments.FindAsync(vehicleEntry.EstablishmentId);

        if (vehicle == null)
        {
            throw new Exception("Vehicle not found.");
        }
        if (establishment == null)
        {
            throw new Exception("Establishment not found.");
        }

        _context.VehiclesEntry.Add(vehicleEntry);
        await _context.SaveChangesAsync();
        return vehicleEntry;
    }

    public async Task DeleteVehicleEntry(Guid id)
    {
        var vehicleEntry = await _context.VehiclesEntry.FindAsync(id);
        if (vehicleEntry != null)
        {
            _context.VehiclesEntry.Remove(vehicleEntry);
            await _context.SaveChangesAsync();
        }
    }
}