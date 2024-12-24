using FluentValidation;
using Taboo.DTOs.Languages;

namespace Taboo.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code can not be empty")
                .NotNull().WithMessage("Code can not be null")
                .MaximumLength(2).WithMessage("Code's length must be 2");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MaximumLength(3).WithMessage("Name's length must be 3");

            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("Icon can not be empty")
                .NotNull().WithMessage("Icon can not be null")
                .Matches("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?").WithMessage("Icon Url must be url")
                .MaximumLength(128);
        }
    }
}
