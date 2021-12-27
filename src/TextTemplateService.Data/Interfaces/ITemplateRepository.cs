using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface ITemplateRepository
  {
    Task<Guid?> CreateAsync(DbTemplate request);

    Task<bool> EditAsync(Guid emailTemplateId, JsonPatchDocument<DbTemplate> request);

    Task<DbTemplate> GetAsync(Guid emailTemplateId);

    Task<DbTemplate> GetAsync(int type);

    Task<(List<DbTemplate> dbEmailTempates, int totalCount)> FindAsync(FindTemplateFilter filter);
  }
}

