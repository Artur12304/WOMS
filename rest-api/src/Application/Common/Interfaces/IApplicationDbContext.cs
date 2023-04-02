using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Entities;

namespace RestApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Cart> Carts { get; }

    DbSet<Product> Products { get; }

    DbSet<Client> Clients { get; }

    DbSet<Order> Orders { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
