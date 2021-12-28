using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface ITemplateTextInfoMapper
  {
    TemplateTextInfo Map(DbTemplateText dbEmailTemplateText);
  }
}
