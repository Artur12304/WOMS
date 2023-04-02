using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(v => v.OrderStatus)
            .NotEmpty().WithMessage("OrderStatus is required.");
    }
}
