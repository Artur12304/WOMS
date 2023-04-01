using RestApi.Domain.Common;

namespace RestApi.Domain.Entities;

public class Client : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
