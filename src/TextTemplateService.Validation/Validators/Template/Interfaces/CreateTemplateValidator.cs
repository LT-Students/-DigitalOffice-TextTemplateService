using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.Template.Interfaces
{
  [AutoInject]
  public interface ICreateTemplateValidator : IValidator<TemplateRequest>
  {
  }
}
