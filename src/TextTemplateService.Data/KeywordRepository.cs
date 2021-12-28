using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Provider;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data
{
  public class KeywordRepository : IKeywordRepository
  {
    private readonly IDataProvider _provider;

    public KeywordRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task CreateAsync(List<DbKeyword> dbKeywords, int service)
    {
      if (dbKeywords is null || !dbKeywords.Any())
      {
        return;
      }

      IQueryable<DbKeyword> serviceKeywords = _provider.Keywords.Where(k => k.Service == service);

      foreach (DbKeyword dbKeyword in dbKeywords)
      {
        if (!serviceKeywords.Any(k => k.EntityName == dbKeyword.EntityName && k.Keyword == dbKeyword.Keyword))
        {
          _provider.Keywords.Add(dbKeyword);
        }
      }

      await _provider.SaveAsync();
    }

    public async Task<List<DbKeyword>> GetAsync(int service)
    {
      return await _provider.Keywords
        .Where(k => k.Service == service)
        .ToListAsync();
    }
  }
}
