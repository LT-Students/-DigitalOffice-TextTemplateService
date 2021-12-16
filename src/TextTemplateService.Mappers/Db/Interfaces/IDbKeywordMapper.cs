using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.ParseEntity;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbKeywordMapper
  {
    DbKeyword Map(CreateKeywordRequest request);
  }
}
