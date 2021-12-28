using FluentValidation;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.Template.Interfaces
{
  [AutoInject]
  public interface IEditTemplateValidator : IValidator<JsonPatchDocument<EditTemplateRequest>>
  {
  }
}
