using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Entities;

public class VehicleEntry
{
    public Guid Id { get; init; }
    public Guid VehicleId { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime Time { get; set; }

    public VehicleEntry(Guid vehicleId, Guid establishmentId, DateTime time)
    {
        if (!IsValidVehicleId(vehicleId))
        {
            throw new ValidationException("Id do veículo inválido.");
        }
        if (!IsValidEstablishmentId(establishmentId))
        {
            throw new ValidationException("Id do estabelecimento inválido.");
        }

        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        Time = time;
    }

    private static bool IsValidVehicleId(Guid vehicleId)
    {
        return vehicleId != Guid.Empty;
    }

    private static bool IsValidEstablishmentId(Guid establishmentId)
    {
        return establishmentId != Guid.Empty;
    }
}
