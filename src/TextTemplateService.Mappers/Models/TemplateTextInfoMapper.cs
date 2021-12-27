using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class TemplateTextInfoMapper : ITemplateTextInfoMapper
  {
    public TemplateTextInfo Map(DbTemplateText dbEmailTemplateText)
    {
      if (dbEmailTemplateText == null)
      {
        return null;
      }

      return new TemplateTextInfo
      {
        Id = dbEmailTemplateText.Id,
        Subject = dbEmailTemplateText.Subject,
        Text = dbEmailTemplateText.Text,
        Language = dbEmailTemplateText.Language
      };
    }
  }
}
