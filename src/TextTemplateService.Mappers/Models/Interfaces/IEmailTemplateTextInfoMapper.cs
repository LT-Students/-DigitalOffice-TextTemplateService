using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface IEmailTemplateTextInfoMapper
  {
    EmailTemplateTextInfo Map(DbEmailTemplateText dbEmailTemplateText);
  }
}
