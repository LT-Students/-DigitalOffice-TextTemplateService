using FluentValidation;
using LT.DigitalOffice.TextTemplateService.Validation.Validators.TemplateText.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.TemplateText
{
  public class CreateTemplateTextValidator : AbstractValidator<TemplateTextRequest>, ICreateTemplateTextValidator
  {
    public CreateTemplateTextValidator()
    {
      RuleFor(ett => ett.TemplateId)
        .NotEmpty().WithMessage("Email template id must not be empty.");

      RuleFor(ett => ett.Subject)
        .NotEmpty().WithMessage("Subject must not be empty.");

      RuleFor(ett => ett.Text)
        .NotEmpty().WithMessage("Text must not be empty.");

      RuleFor(ett => ett.Language)
        .Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Language must not be empty.")
        .Must(ett => ett.Trim().Length == 2).WithMessage("Language must contain two letters.");
    }
  }
}
