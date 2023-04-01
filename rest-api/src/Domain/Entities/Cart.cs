using RestApi.Domain.Common;

namespace RestApi.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public Client Client { get; set; }

    public IEnumerable<Product> Products { get; set; }

    public decimal CartAmount { get; set; }
}
