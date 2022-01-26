using System;
using System.Threading.Tasks;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Provider;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data
{
  public class EndpointTemplateRepository : IEndpointTemplateRepository
  {
    private readonly IDataProvider _provider;
    public EndpointTemplateRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<DbTemplate> GetAsync(Guid endpointId)
    {
      return (await _provider.EndpointsTemplates
        .Include(et => et.Template)
        .ThenInclude(t => t.TextsTemplates)
        .FirstOrDefaultAsync(et => et.EndpointId == endpointId && et.IsActive))
      ?.Template;
    }
  }
}
