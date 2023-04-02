using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.ProductId)
            .NotEmpty().WithMessage("Client is required to create a Cart.");
    }
}
