using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface IKeywordRepository
  {
    Task CreateAsync(List<DbKeyword> dbKeywords, int service);

    Task<List<DbKeyword>> GetAsync(int service);
  }
}
