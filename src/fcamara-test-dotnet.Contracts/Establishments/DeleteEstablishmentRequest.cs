
namespace fcamara_test_dotnet.Contracts.Establishments;

public class DeleteEstablishmentRequest
{
    public Guid Id { get; set; }

    public DeleteEstablishmentRequest(Guid id)
    {
        Id = id;
    }
}