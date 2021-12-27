using FluentValidation;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using LT.DigitalOffice.TextTemplateService.Validation.Validators.Template.Interfaces;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.Template
{
  public class CreateTemplateValidator : AbstractValidator<TemplateRequest>, ICreateEmailTemplateValidator
  {
    public CreateTemplateValidator()
    {
      RuleFor(et => et.Name)
        .NotEmpty().WithMessage("Email template name must not be empty.");

      RuleFor(et => et.Type)
        .IsInEnum().WithMessage("Incorrect Email template type.");

      RuleFor(et => et.TemplateTexts)
        .NotEmpty().WithMessage("Email template texts must not be empty.");

      RuleForEach(et => et.TemplateTexts)
        .NotNull().WithMessage("Email template text must not be null.")
        .ChildRules(ett =>
        {
          ett.RuleFor(ett => ett.Subject)
            .NotEmpty().WithMessage("Subject must not be empty.");

          ett.RuleFor(ett => ett.Text)
            .NotEmpty().WithMessage("Text must not be empty.");

          ett.RuleFor(ett => ett.Language)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Language must not be empty.")
            .Must(ett => ett.Trim().Length == 2).WithMessage("Language must contain two letters.");
        });
    }
  }
}
