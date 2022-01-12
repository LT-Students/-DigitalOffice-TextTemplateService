using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface ITemplateTextRepository
  {
    Task<Guid?> CreateAsync(DbTextTemplate request);

    Task<bool> EditAsync(Guid emailTemplateTextId, JsonPatchDocument<DbTextTemplate> patch);
  }
}
