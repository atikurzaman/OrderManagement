
namespace OrderManagement.Application.Validators.SubElement
{
    public class SubElementForCreateDtoValidator : AbstractValidator<SubElementForCreateDto>
    {
        public SubElementForCreateDtoValidator()
        {
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
