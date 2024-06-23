using fcamara_test_dotnet.Application.Common.DTOs.Vehicle;
using fcamara_test_dotnet.Application.Common.Interfaces.Persistence;
using fcamara_test_dotnet.Application.Common.Interfaces.Services;
using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Application.Common.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<Vehicle>> GetVehicles()
    {
        return await _vehicleRepository.GetVehicles();
    }

    public async Task<Vehicle?> GetVehicleById(GetVehicleByIdDTO getVehicleByIdDTO)
    {
        return await _vehicleRepository.GetVehicleById(getVehicleByIdDTO.Id);
    }

    public async Task<Vehicle> CreateVehicle(CreateVehicleDTO createVehicleDTO)
    {
        var vehicle = new Vehicle(
            createVehicleDTO.Brand,
            createVehicleDTO.Model,
            createVehicleDTO.Color,
            createVehicleDTO.Plate,
            createVehicleDTO.Type
        );

        return await _vehicleRepository.CreateVehicle(vehicle);
    }

    public async Task<Vehicle> UpdateVehicle(UpdateVehicleDTO updateVehicleDTO)
    {
        var vehicle = await _vehicleRepository.GetVehicleById(updateVehicleDTO.Id);

        if (vehicle == null)
        {
            throw new NotFoundException("Vehicle not found.");
        }

        var updatedVehicle = new Vehicle(
            updateVehicleDTO.Brand ?? vehicle.Brand,
            updateVehicleDTO.Model ?? vehicle.Model,
            updateVehicleDTO.Color ?? vehicle.Color,
            updateVehicleDTO.Plate ?? vehicle.Plate,
            updateVehicleDTO.Type ?? vehicle.Type,
            vehicle.Id
        );

        return await _vehicleRepository.UpdateVehicle(updatedVehicle);
    }

    public async Task DeleteVehicle(DeleteVehicleDTO deleteVehicleDTO)
    {
        await _vehicleRepository.DeleteVehicle(deleteVehicleDTO.Id);
    }
}