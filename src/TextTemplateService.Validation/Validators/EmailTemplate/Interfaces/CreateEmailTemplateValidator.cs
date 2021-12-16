using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplate.Interfaces
{
  [AutoInject]
  public interface ICreateEmailTemplateValidator : IValidator<EmailTemplateRequest>
  {
  }
}
