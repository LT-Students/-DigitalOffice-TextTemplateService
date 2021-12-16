using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplate.Interfaces
{
  [AutoInject]
  public interface IEditEmailTemplateValidator : IValidator<JsonPatchDocument<EditEmailTemplateRequest>>
  {
  }
}
