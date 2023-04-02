using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Carts.Commands.UpdateCart;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCartCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
