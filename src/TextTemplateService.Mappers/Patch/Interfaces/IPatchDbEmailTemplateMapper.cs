using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces
{
  [AutoInject]
  public interface IPatchDbEmailTemplateMapper
  {
    JsonPatchDocument<DbEmailTemplate> Map(
      JsonPatchDocument<EditEmailTemplateRequest> request);
  }
}
