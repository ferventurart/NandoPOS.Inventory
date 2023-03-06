using FluentValidation;

namespace Application.Stores.CreateStore;

public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
{
    public CreateStoreCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.Manager)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty()
            .MaximumLength(200);
    }
}
