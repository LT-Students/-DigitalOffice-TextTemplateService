using System;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class KeywordInfoMapper : IKeywordInfoMapper
  {
    public KeywordInfo Map(DbKeyword dbKeyword)
    {
      if (dbKeyword == null)
      {
        return null;
      }

      return new KeywordInfo
      {
        Id = dbKeyword.Id,
        Keyword = dbKeyword.Keyword,
        ServiceName = (ServiceName)dbKeyword.ServiceName,
        EntityName = dbKeyword.EntityName.StartsWith("db", StringComparison.OrdinalIgnoreCase) ?
          dbKeyword.EntityName[2..] :
          dbKeyword.EntityName,
        PropertyName = dbKeyword.PropertyName
      };
    }
  }
}
