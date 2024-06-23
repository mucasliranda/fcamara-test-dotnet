using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;
using fcamara_test_dotnet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Infrastructure.Persistence;

public class VehicleRepository: IVehicleRepository {
    private readonly AppDbContext _context;

    public VehicleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleById(Guid id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
    {
        var existingVehicle = _context.Vehicles.Local.FirstOrDefault(v => v.Id == vehicle.Id);
        if (existingVehicle != null)
        {
            _context.Entry(existingVehicle).State = EntityState.Detached;
            _context.Vehicles.Attach(vehicle);
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vehicle;
        }
        throw new NotFoundException("Vehicle not found.");
    }

    public async Task DeleteVehicle(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAllVehicles()
    {
        await _context.Vehicles.ForEachAsync(vehicle => _context.Vehicles.Remove(vehicle));
        await _context.SaveChangesAsync();
    }
}