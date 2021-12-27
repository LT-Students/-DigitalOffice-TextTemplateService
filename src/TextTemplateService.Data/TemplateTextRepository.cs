using System;
using System.Threading.Tasks;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Provider;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data
{
  public class TemplateTextRepository : ITemplateTextRepository
  {
    private readonly IDataProvider _provider;

    public TemplateTextRepository(IDataProvider provider)
    {
      _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbTemplateText request)
    {
      if (request == null)
      {
        return null;
      }

      _provider.TemplateTexts.Add(request);
      await _provider.SaveAsync();

      return request.Id;
    }

    public async Task<bool> EditAsync(Guid emailTemplateTextId, JsonPatchDocument<DbTemplateText> patch)
    {
      if (patch == null)
      {
        return false;
      }

      DbTemplateText dbEmailTemplateText = await _provider.TemplateTexts
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
