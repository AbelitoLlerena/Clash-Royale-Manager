using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandValidator : Validator<RegisterCommand>
{
    private readonly IUserRepository _repository;

    public RegisterCommandValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("The password is required.")
            .MinimumLength(6).WithMessage("The password must have at least 6 characters.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("The username is required.")
            .MinimumLength(3).MaximumLength(10).WithMessage("The username must have 3-10 characters.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The email is required.")
            .EmailAddress().WithMessage("The Email provided is not valid.")
            .Must(UniqueEmail).WithMessage("The email provided is registred.");
    }

    private bool UniqueEmail(string email)
    {
        return _repository.GetByEmail(email) is not null;
    }
}