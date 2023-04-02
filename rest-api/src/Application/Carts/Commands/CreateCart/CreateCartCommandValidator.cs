using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Carts.Commands.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCartCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("Client is required to create a Cart.");
    }
}
