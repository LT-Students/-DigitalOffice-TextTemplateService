using LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch
{
  public class PatchDbTemplateTextMapper : IPatchDbTemplateTextMapper
  {
    public JsonPatchDocument<DbTextTemplate> Map(
      JsonPatchDocument<EditTemplateTextRequest> request)
    {
      if (request == null)
      {
        return null;
      }

      JsonPatchDocument<DbTextTemplate> dbPatch = new();

      foreach (var item in request.Operations)
      {
        dbPatch.Operations.Add(new Operation<DbTextTemplate>(item.op, item.path, item.from, item.value));
      }

      return dbPatch;
    }
  }
}
