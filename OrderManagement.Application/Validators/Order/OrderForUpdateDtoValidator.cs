
namespace OrderManagement.Application.Validators.Order
{
    public class OrderForUpdateDtoValidator : AbstractValidator<OrderForUpdateDto>
    {
        public OrderForUpdateDtoValidator()
        {
            RuleFor(s => s.Id)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
             .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters");

            RuleFor(s => s.State)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
             .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters");
        }
    }
}
