using fcamara_test_dotnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fcamara_test_dotnet.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public DbSet<Establishment> Establishments { get; set; }
	public DbSet<Vehicle> Vehicles { get; set; }
	public DbSet<VehicleEntry> VehiclesEntry { get; set; }
	public DbSet<VehicleExit> VehiclesExit { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
}
