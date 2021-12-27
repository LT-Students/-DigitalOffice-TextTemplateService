using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.TemplateText.Interfaces
{
  [AutoInject]
  public interface ICreateTemplateTextValidator : IValidator<TemplateTextRequest>
  {
  }
}
