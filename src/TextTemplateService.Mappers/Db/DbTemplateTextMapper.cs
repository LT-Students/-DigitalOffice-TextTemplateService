using System;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbTemplateTextMapper : IDbTemplateTextMapper
  {
    public DbTemplateText Map(TemplateTextRequest request, Guid? emailTemplateId = null)
    {
      if (request == null)
      {
        return null;
      }

      return new DbTemplateText
      {
        Id = Guid.NewGuid(),
        TemplateId = emailTemplateId.HasValue ? emailTemplateId.Value : request.TemplateId.Value,
        Subject = request.Subject,
        Text = request.Text,
        Language = request.Language
      };
    }
  }
}

