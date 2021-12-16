using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface IEmailTemplateRepository
  {
    Task<Guid?> CreateAsync(DbEmailTemplate request);

    Task<bool> EditAsync(Guid emailTemplateId, JsonPatchDocument<DbEmailTemplate> request);

    Task<DbEmailTemplate> GetAsync(Guid emailTemplateId);

    Task<DbEmailTemplate> GetAsync(int type);

    Task<(List<DbEmailTemplate> dbEmailTempates, int totalCount)> FindAsync(FindEmailTemplateFilter filter);
  }
}

