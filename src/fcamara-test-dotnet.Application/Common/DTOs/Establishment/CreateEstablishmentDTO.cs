
namespace fcamara_test_dotnet.Application.Common.DTOs.Establishment;

public class CreateEstablishmentDTO
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int MotorcycleSpots { get; set; }
    public int CarSpots { get; set; }

    public CreateEstablishmentDTO(string name, string cnpj, string address, string phone, int motorcycleSpots, int carSpots)
    {
        Name = name;
        CNPJ = cnpj;
        Address = address;
        Phone = phone;
        MotorcycleSpots = motorcycleSpots;
        CarSpots = carSpots;
    }
}