using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateClientCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
