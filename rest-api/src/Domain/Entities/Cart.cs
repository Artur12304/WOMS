using RestApi.Domain.Common;

namespace RestApi.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public int ClientId { get; set; }

    public List<int>? ProductIds { get; set; }

    public decimal CartAmount { get; set; }
}
