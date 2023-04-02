using MediatR;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = new Product
        {
            ProductId = request.ProductId,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            ProductCategory = request.ProductCategory,
        };

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}