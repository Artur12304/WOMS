using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.CartId)
            .NotEmpty().WithMessage("CartId is required to create an Order.");
    }
}
