using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;
using fcamara_test_dotnet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Infrastructure.Persistence;

public class EstablishmentRepository: IEstablishmentRepository {
    private readonly AppDbContext _context;

    public EstablishmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Establishment>> GetEstablishments()
    {
        return await _context.Establishments.ToListAsync();
    }

    public async Task<Establishment?> GetEstablishmentById(Guid id)
    {
        return await _context.Establishments.FindAsync(id);
    }

    public async Task<Establishment>CreateEstablishment(Establishment establishment)
    {
        _context.Establishments.Add(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }

    public async Task<Establishment> UpdateEstablishment(Establishment establishment)
    {
        var existingEstablishment = _context.Establishments.Local.FirstOrDefault(v => v.Id == establishment.Id);
        if (existingEstablishment != null)
        {
            _context.Entry(existingEstablishment).State = EntityState.Detached;
            _context.Establishments.Attach(establishment);
            _context.Entry(establishment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return establishment;
        }
        throw new NotFoundException("Establishment not found.");
    }

    public async Task DeleteEstablishment(Guid id)
    {
        var establishment = await _context.Establishments.FindAsync(id);
        if (establishment != null)
        {
            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();
        }
        else {
            throw new NotFoundException("Establishment not found.");
        }
    }

    public async Task DeleteAllEstablishments()
    {
        await _context.Establishments.ForEachAsync(vehicle => _context.Establishments.Remove(vehicle));
        await _context.SaveChangesAsync();
    }
}