using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class KeywordInfoMapper : IKeywordInfoMapper
  {
    public KeywordInfo Map(DbKeyword dbKeyword)
    {
      if (dbKeyword is null)
      {
        return null;
      }

      return new KeywordInfo
      {
        Id = dbKeyword.Id,
        Service = ((SourceKeywords)dbKeyword.Service).ToString(),
        EntityName = dbKeyword.EntityName,
        Keyword = dbKeyword.Keyword
      };
    }
  }
}
