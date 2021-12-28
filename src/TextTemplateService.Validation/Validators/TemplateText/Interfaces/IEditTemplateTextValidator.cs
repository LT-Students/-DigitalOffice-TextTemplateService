using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.TemplateText.Interfaces
{
  [AutoInject]
  public interface IEditTemplateTextValidator : IValidator<JsonPatchDocument<EditTemplateTextRequest>>
  {
  }
}
