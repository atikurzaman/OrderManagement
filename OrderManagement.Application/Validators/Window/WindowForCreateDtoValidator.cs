
namespace OrderManagement.Application.Validators.Window
{
    public class WindowForCreateDtoValidator : AbstractValidator<WindowForCreateDto>
    {
        public WindowForCreateDtoValidator()
        {
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
