using System;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Mappers.Patch.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Patch
{
  public class PatchDbEmailTemplateMapper : IPatchDbEmailTemplateMapper
  {
    public JsonPatchDocument<DbEmailTemplate> Map(
      JsonPatchDocument<EditEmailTemplateRequest> request)
    {
      if (request == null)
      {
        return null;
      }

      JsonPatchDocument<DbEmailTemplate> dbPatch = new();

      foreach (var item in request.Operations)
      {
        if (item.path.EndsWith(nameof(EditEmailTemplateRequest.Type), StringComparison.OrdinalIgnoreCase))
        {
          dbPatch.Operations.Add(new Operation<DbEmailTemplate>(
            item.op, item.path, item.from, (int)Enum.Parse(typeof(EmailTemplateType), item.value.ToString())));
          continue;
        }
        dbPatch.Operations.Add(new Operation<DbEmailTemplate>(item.op, item.path, item.from, item.value));
      }

      return dbPatch;
    }
  }
}
