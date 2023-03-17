
namespace OrderManagement.Application.Validators.Window
{
    public class WindowForUpdateDtoValidator : AbstractValidator<WindowForUpdateDto>
    {
        public WindowForUpdateDtoValidator()
        {
            RuleFor(s => s.Id)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
             .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters");

            RuleFor(s => s.QuantityOfWindows)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(s => s.TotalSubElements)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(s => s.OrderId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
