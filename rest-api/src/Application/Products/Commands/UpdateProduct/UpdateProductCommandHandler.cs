using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = await _context.Products.FindAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.ProductId = request.ProductId;
        entity.Name = request.Name;
        entity.Price = request.Price;
        entity.Description = request.Description;
        entity.ProductCategory = request.ProductCategory;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}