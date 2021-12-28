using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces
{
  [AutoInject]
  public interface IPatchDbTemplateMapper
  {
    JsonPatchDocument<DbTemplate> Map(
      JsonPatchDocument<EditTemplateRequest> request);
  }
}
