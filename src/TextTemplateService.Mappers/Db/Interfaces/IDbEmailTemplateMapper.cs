using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbEmailTemplateMapper
  {
    DbEmailTemplate Map(EmailTemplateRequest request);
  }
}
