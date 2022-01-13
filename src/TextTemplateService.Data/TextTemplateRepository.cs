using System;
using System.Threading.Tasks;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Provider;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data
{
  public class TextTemplateRepository : ITextTemplateRepository
  {
    private readonly IDataProvider _provider;

    public TextTemplateRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbTextTemplate request)
    {
      if (request == null)
      {
        return null;
      }

      _provider.TextTemplates.Add(request);
      await _provider.SaveAsync();

      return request.Id;
    }

    public async Task<bool> EditAsync(Guid emailTemplateTextId, JsonPatchDocument<DbTextTemplate> patch)
    {
      if (patch == null)
      {
        return false;
      }

      DbTextTemplate dbEmailTemplateText = await _provider.TextTemplates
        .FirstOrDefaultAsync(et => et.Id == emailTemplateTextId);

      if (dbEmailTemplateText == null)
      {
        return false;
      }

      patch.ApplyTo(dbEmailTemplateText);
      await _provider.SaveAsync();

      return true;
    }
  }
}
