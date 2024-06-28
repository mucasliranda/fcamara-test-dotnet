using System.Text.RegularExpressions;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Entities;

public class Establishment
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public int MotorcycleSpots { get; private set; }
    public int CarSpots { get; private set; }
    
    public Establishment(string name, string cnpj, string address, string phone, int motorcycleSpots, int carSpots, Guid id = default)
    {
        if (!IsValidName(name))
        {
            throw new ValidationException("Nome inválido.");
        }
        if (!IsValidCnpj(cnpj))
        {
            throw new ValidationException("CNPJ inválido.");
        }
        if (!IsValidAddress(address))
        {
            throw new ValidationException("Endereço inválido.");
        }
        if (!IsValidPhone(phone))
        {
            throw new ValidationException("Telefone inválido.");
        }
        if (!IsValidMotorcycleSpots(motorcycleSpots))
        {
            throw new ValidationException("Vagas de moto inválidas.");
        }
        if (!IsValidCarSpots(carSpots))
        {
            throw new ValidationException("Vagas de carro inválidas.");
        }

        Id = id;
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Phone = phone;
        MotorcycleSpots = motorcycleSpots;
        CarSpots = carSpots;
    }

    private static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    private static bool IsValidCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj)) return false;

        var regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$|^\d{14}$");
        return regex.IsMatch(cnpj);
    }

    private static bool IsValidAddress(string address)
    {
        return !string.IsNullOrWhiteSpace(address);
    }

    private static bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return false;

        var regex = new Regex(@"^\d{11}$");
        return regex.IsMatch(phone);
    }

    private static bool IsValidMotorcycleSpots(int motorcycleSpots)
    {
        return motorcycleSpots >= 0;
    }

    private static bool IsValidCarSpots(int carSpots)
    {
        return carSpots >= 0;
    }
}