using System;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbEmailTemplateTextMapper
  {
    DbEmailTemplateText Map(EmailTemplateTextRequest request, Guid? emailTemplateId = null);
  }
}
