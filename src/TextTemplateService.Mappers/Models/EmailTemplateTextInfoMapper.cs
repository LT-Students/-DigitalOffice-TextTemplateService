using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class EmailTemplateTextInfoMapper : IEmailTemplateTextInfoMapper
  {
    public EmailTemplateTextInfo Map(DbEmailTemplateText dbEmailTemplateText)
    {
      if (dbEmailTemplateText == null)
      {
        return null;
      }

      return new EmailTemplateTextInfo
      {
        Id = dbEmailTemplateText.Id,
        Subject = dbEmailTemplateText.Subject,
        Text = dbEmailTemplateText.Text,
        Language = dbEmailTemplateText.Language
      };
    }
  }
}
