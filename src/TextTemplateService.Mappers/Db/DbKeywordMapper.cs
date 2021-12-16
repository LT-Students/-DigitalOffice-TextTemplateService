using System;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.ParseEntity;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbKeywordMapper : IDbKeywordMapper
  {
    public DbKeyword Map(CreateKeywordRequest request)
    {
      if (request == null)
      {
        return null;
      }

      return new DbKeyword
      {
        Id = Guid.NewGuid(),
        Keyword = request.Keyword,
        ServiceName = (int)request.ServiceName,
        EntityName = "Db" + request.EntityName,
        PropertyName = request.PropertyName
      };
    }
  }
}
