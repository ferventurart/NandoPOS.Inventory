using FluentValidation;

namespace Application.Stores.UpdateStore;

public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
{
    public UpdateStoreCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty();

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
