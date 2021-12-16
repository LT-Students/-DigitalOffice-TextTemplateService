using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplateText.Interfaces
{
  [AutoInject]
  public interface ICreateEmailTemplateTextValidator : IValidator<EmailTemplateTextRequest>
  {
  }
}
