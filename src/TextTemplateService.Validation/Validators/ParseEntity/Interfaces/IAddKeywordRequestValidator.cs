using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.ParseEntity;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.ParseEntity.Interfaces
{
  [AutoInject]
  public interface IAddKeywordRequestValidator : IValidator<CreateKeywordRequest>
  {
  }
}
