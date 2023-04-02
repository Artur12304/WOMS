using FluentValidation;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Clients.Commands.CreateClient;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateClientCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required to create a Client.");
        RuleFor(v => v.Surname)
            .NotEmpty().WithMessage("Surname is required to create a Client.");
        RuleFor(v => v.Address)
            .NotEmpty().WithMessage("Address is required to create a Client.");
        RuleFor(v => v.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required to create a Client.");
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required to create a Client.");
    }
}
