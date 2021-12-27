using System;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch
{
  public class PatchDbTemplateMapper : IPatchDbTemplateMapper
  {
    public JsonPatchDocument<DbTemplate> Map(
      JsonPatchDocument<EditTemplateRequest> request)
    {
      if (request == null)
      {
        return null;
      }

      JsonPatchDocument<DbTemplate> dbPatch = new();

      foreach (var item in request.Operations)
      {
        if (item.path.EndsWith(nameof(EditTemplateRequest.Type), StringComparison.OrdinalIgnoreCase))
        {
          dbPatch.Operations.Add(new Operation<DbTemplate>(
            item.op, item.path, item.from, (int)Enum.Parse(typeof(EmailTemplateType), item.value.ToString())));
          continue;
        }
        dbPatch.Operations.Add(new Operation<DbTemplate>(item.op, item.path, item.from, item.value));
      }

      return dbPatch;
    }
  }
}
