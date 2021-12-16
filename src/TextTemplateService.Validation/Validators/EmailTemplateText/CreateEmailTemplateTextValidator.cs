using FluentValidation;
using LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplateText.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplateText
{
  public class CreateEmailTemplateTextValidator : AbstractValidator<EmailTemplateTextRequest>, ICreateEmailTemplateTextValidator
  {
    public CreateEmailTemplateTextValidator()
    {
      RuleFor(ett => ett.EmailTemplateId)
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
