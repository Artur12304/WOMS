namespace RestApi.Domain.Enums;

public enum OrderStatus
{
    None = 0,
    New = 1,
    Pending = 2,
    InProgress = 3,
    Shipped = 4,
    Delivered = 5,
    Cancelled = 6,
    Returned = 7
}
