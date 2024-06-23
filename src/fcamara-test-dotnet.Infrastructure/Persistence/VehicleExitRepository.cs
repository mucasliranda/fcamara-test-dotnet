using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class VehicleExitRepository: IVehicleExitRepository {
    private readonly AppDbContext _context;

    public VehicleExitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VehicleExit?> GetVehicleExitById(Guid id)
    {
        return await _context.VehiclesExit.FindAsync(id);
    }

    public async Task<IEnumerable<VehicleExit>> GetVehicleExitsByVehicleId(Guid vehicleId)
    {
        return await _context.VehiclesExit.Where(vehicleExit => vehicleExit.VehicleId == vehicleId).ToListAsync();
    }

    public async Task<IEnumerable<VehicleExit>> GetVehicleExitsByEstablishmentId(Guid establishmentId)
    {
        return await _context.VehiclesExit.Where(vehicleExit => vehicleExit.EstablishmentId == establishmentId).ToListAsync();
    }

    public async Task<VehicleExit> CreateVehicleExit(VehicleExit vehicleExit)
    {
        var vehicle = await _context.Vehicles.FindAsync(vehicleExit.VehicleId);
        var establishment = await _context.Establishments.FindAsync(vehicleExit.EstablishmentId);

        if (vehicle == null)
        {
            throw new Exception("Vehicle not found.");
        }
        if (establishment == null)
        {
            throw new Exception("Establishment not found.");
        }

        _context.VehiclesExit.Add(vehicleExit);
        await _context.SaveChangesAsync();
        return vehicleExit;
    }

    public async Task DeleteVehicleExit(Guid id)
    {
        var vehicleExit = await _context.VehiclesExit.FindAsync(id);
        if (vehicleExit != null)
        {
            _context.VehiclesExit.Remove(vehicleExit);
            await _context.SaveChangesAsync();
        }
    }
}