using RestApi.Application.Common.Interfaces;

namespace RestApi.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
