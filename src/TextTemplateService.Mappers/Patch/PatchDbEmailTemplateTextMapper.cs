using LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch
{
  public class PatchDbEmailTemplateTextMapper : IPatchDbEmailTemplateTextMapper
  {
    public JsonPatchDocument<DbEmailTemplateText> Map(
      JsonPatchDocument<EditEmailTemplateTextRequest> request)
    {
      if (request == null)
      {
        return null;
      }

      JsonPatchDocument<DbEmailTemplateText> dbPatch = new();

      foreach (var item in request.Operations)
      {
        dbPatch.Operations.Add(new Operation<DbEmailTemplateText>(item.op, item.path, item.from, item.value));
      }

      return dbPatch;
    }
  }
}
