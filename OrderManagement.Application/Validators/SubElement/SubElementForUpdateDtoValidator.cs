
namespace OrderManagement.Application.Validators.SubElement
{
    public class SubElementForUpdateDtoValidator : AbstractValidator<SubElementForUpdateDto>
    {
        public SubElementForUpdateDtoValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(s => s.Element)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(s => s.Type)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters");


            RuleFor(s => s.Width)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();


            RuleFor(s => s.Height)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(s => s.WindowId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
