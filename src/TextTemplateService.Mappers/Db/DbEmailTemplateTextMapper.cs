using System;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbEmailTemplateTextMapper : IDbEmailTemplateTextMapper
  {
    public DbEmailTemplateText Map(EmailTemplateTextRequest request, Guid? emailTemplateId = null)
    {
      if (request == null)
      {
        return null;
      }

      return new DbEmailTemplateText
      {
        Id = Guid.NewGuid(),
        EmailTemplateId = emailTemplateId.HasValue ? emailTemplateId.Value : request.EmailTemplateId.Value,
        Subject = request.Subject,
        Text = request.Text,
        Language = request.Language
      };
    }
  }
}

