using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

public class VehicleEntryExit
{
    public Guid Id { get; init; }
    public Guid VehicleId { get; private set; }
    public Guid EstablishmentId { get; private set; }
    public DateTime EntryTime { get; private set; }
    public DateTime? ExitTime { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public Establishment Establishment { get; private set; }
    
    public VehicleEntryExit(Guid vehicleId, Guid establishmentId, DateTime entryTime, DateTime? exitTime)
    {
        if (!IsVehicleIdValid(vehicleId))
        {
            throw new ValidationException("Id do veículo inválido.");
        }
        if (!IsEstablishmentIdValid(establishmentId))
        {
            throw new ValidationException("Id do estabelecimento inválido.");
        }

        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
        EntryTime = entryTime;
        ExitTime = exitTime;
    }

    private static bool IsVehicleIdValid(Guid vehicleId)
    {
        return vehicleId != Guid.Empty;
    }

    private static bool IsEstablishmentIdValid(Guid EstablishmentId)
    {
        return EstablishmentId != Guid.Empty;
    }
}