using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplateText.Interfaces
{
  [AutoInject]
  public interface IEditEmailTemplateTextValidator : IValidator<JsonPatchDocument<EditEmailTemplateTextRequest>>
  {
  }
}
