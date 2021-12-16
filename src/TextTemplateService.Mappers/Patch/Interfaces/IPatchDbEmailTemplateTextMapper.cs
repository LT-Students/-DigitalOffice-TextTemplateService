using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces
{
  [AutoInject]
  public interface IPatchDbEmailTemplateTextMapper
  {
    JsonPatchDocument<DbEmailTemplateText> Map(
      JsonPatchDocument<EditEmailTemplateTextRequest> request);
  }
}
