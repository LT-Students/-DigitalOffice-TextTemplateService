using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Provider;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data
{
  public class TextTemplateRepository : ITextTemplateRepository
  {
    private readonly IDataProvider _provider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TextTemplateRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor)
    {
      _provider = provider;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid?> CreateAsync(DbTextTemplate request)
    {
      if (request == null)
      {
        return null;
      }

      _provider.TextsTemplates.Add(request);
      await _provider.SaveAsync();

      return request.Id;
    }

    public async Task<bool> EditAsync(Guid emailTemplateTextId, JsonPatchDocument<DbTextTemplate> patch)
    {
      if (patch == null)
      {
        return false;
      }

      DbTextTemplate dbEmailTemplateText = await _provider.TextsTemplates
        .FirstOrDefaultAsync(et => et.Id == emailTemplateTextId);

      if (dbEmailTemplateText == null)
      {
        return false;
      }

      dbEmailTemplateText.ModifiedBy = _httpContextAccessor.HttpContext.GetUserId();
      dbEmailTemplateText.ModifiedAtUtc = DateTime.UtcNow;
      patch.ApplyTo(dbEmailTemplateText);

      await _provider.SaveAsync();
      return true;
    }
  }
}
