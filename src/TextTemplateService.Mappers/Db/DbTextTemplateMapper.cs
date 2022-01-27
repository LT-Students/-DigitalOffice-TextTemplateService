using System;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbTextTemplateMapper : IDbTextTemplateMapper
  {
    public DbTextTemplate Map(TemplateTextRequest request, Guid? emailTemplateId = null)
    {
      if (request is null)
      {
        return null;
      }

      return new DbTextTemplate
      {
        Id = Guid.NewGuid(),
        TemplateId = emailTemplateId.HasValue ? emailTemplateId.Value : request.TemplateId.Value,
        Subject = request.Subject,
        Text = request.Text,
        Locale = request.Locale,
        IsActive = true
      };
    }
  }
}

