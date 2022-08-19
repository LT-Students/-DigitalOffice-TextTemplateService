using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface IKeywordRepository
  {
    Task<bool> CreateAsync(List<DbKeyword> dbKeywords);

    Task<List<DbKeyword>> GetAsync(Guid endpointId);

    Task<List<DbKeyword>> GetAsync(List<Guid> endpointsIds);
  }
}
