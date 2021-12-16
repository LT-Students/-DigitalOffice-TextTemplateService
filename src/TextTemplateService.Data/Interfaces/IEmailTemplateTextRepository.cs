using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface IEmailTemplateTextRepository
  {
    Task<Guid?> CreateAsync(DbEmailTemplateText request);

    Task<bool> EditAsync(Guid emailTemplateTextId, JsonPatchDocument<DbEmailTemplateText> patch);
  }
}
