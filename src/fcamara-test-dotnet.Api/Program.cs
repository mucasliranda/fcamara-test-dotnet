using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Services;
using fcamara_test_dotnet.Infrastructure.Data;
using fcamara_test_dotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment()) 
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=../fcamara-test-dotnet.Infrastructure/Data/database.db"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql("Host=db;Port=5432;Database=postgres;Username=postgres;Password=admin;"));
}

builder.Services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleEntryRepository, VehicleEntryRepository>();
builder.Services.AddScoped<IVehicleExitRepository, VehicleExitRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<EstablishmentService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<VehicleEntryService>();
builder.Services.AddScoped<VehicleExitService>();
builder.Services.AddScoped<ReportService>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    if (!app.Environment.IsDevelopment()) {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<AppDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
