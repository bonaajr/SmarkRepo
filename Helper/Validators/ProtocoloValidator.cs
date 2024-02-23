using FluentValidation;

namespace testeSmark.WebApi.Helper.Validators
{
    public class ProtocoloValidator : AbstractValidator<string>
    {
        public ProtocoloValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A string não pode estar vazia.")
                .Length(6).WithMessage("A string deve ter exatamente 6 caracteres.");
        }
    }
}