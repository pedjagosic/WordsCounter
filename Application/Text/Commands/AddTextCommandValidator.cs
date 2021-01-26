using FluentValidation;

namespace Application.Text.Commands
{
    public class AddTextCommandValidator : AbstractValidator<AddTextCommand>
    {
        public AddTextCommandValidator()
        {
            RuleFor(t => t.Text).NotNull();
            RuleFor(t => t.Text).NotEmpty();
        }
    }
}