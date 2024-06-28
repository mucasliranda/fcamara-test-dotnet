using System.Text;
using System.Text.Json;
using fcamara_test_dotnet.Domain.Entities;

namespace fcamara_test_dotnet.Seeder;

public class Program
{
    static async Task Main(string[] args)
    {
        string url = "http://localhost:5126/api";

        var vehicleTypes = new string[] { "car", "motorcycle" };

        Random random = new Random();

        for (int i = 1; i <= 3; i++)
        {
            var establishment = new Establishment(
                $"Estabelecimento {i}",
                "12345678901234",
                $"Rua Teste, {i}",
                "11999999999",
                10,
                10
            );

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(establishment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{url}/establishments", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Estabelecimento cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar estabelecimento.");
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Body: {await response.Content.ReadAsStringAsync()}");
            }

            var establishmentBody = await response.Content.ReadAsStringAsync();
            Establishment establishmentResponse = JsonSerializer.Deserialize<Establishment>(establishmentBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            for (int j = 1; j <= random.Next(12, 24); j++)
            {
                var vehicle = new Vehicle(
                    $"Marca {j}",
                    $"Modelo {j}",
                    $"Cor {j}",
                    $"ABC123{j}",
                    vehicleTypes[j % 2]
                );

                json = JsonSerializer.Serialize(vehicle);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync($"{url}/vehicles", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Veículo cadastrado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao cadastrar veículo.");
                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine($"Response Body: {await response.Content.ReadAsStringAsync()}");
                }

                var vehicleBody = await response.Content.ReadAsStringAsync();
                var vehicleResponse = JsonSerializer.Deserialize<Vehicle>(vehicleBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var vehicleEntry = new VehicleEntry(
                    vehicleResponse.Id,
                    establishmentResponse.Id,
                    DateTime.Today.AddHours(random.Next(6, 15)).AddMinutes(random.Next(0, 180))
                );

                json = JsonSerializer.Serialize(vehicleEntry);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync($"{url}/entry", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Entrada de veículo cadastrada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao cadastrar entrada de veículo.");
                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine($"Response Body: {await response.Content.ReadAsStringAsync()}");
                }

                var vehicleExit = new VehicleExit(
                    vehicleResponse.Id,
                    establishmentResponse.Id,
                    vehicleEntry.Time.AddHours(random.Next(1, 5)).AddMinutes(random.Next(0, 180))
                );

                json = JsonSerializer.Serialize(vehicleExit);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync($"{url}/exit", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Saída de veículo cadastrada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao cadastrar saída de veículo.");
                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine($"Response Body: {await response.Content.ReadAsStringAsync()}");
                }
            }
        }
    }
}
