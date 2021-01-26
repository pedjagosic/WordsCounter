using FluentValidation;

namespace Application.Text.Commands
{
    public class AddTextCommandValidator : AbstractValidator<AddTextCommand>
    {
        public AddTextCommandValidator()
        {
            RuleFor(t => t.Text).NotNull();
            RuleFor(t => t.Text).NotEmpty();
            RuleFor(t => t.Text).Length(1, 2500);
        }
    }
}