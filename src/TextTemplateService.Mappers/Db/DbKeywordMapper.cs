using System;
using System.Collections.Generic;
using System.Linq;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbKeywordMapper : IDbKeywordMapper
  {
    public List<DbKeyword> Map(Guid endpointId, List<string> keywords)
    {
      return keywords.Select(
        k => new DbKeyword
        {
          Id = Guid.NewGuid(),
          EndpointId = endpointId,
          Keyword = k
        }).ToList();
    }
  }
}
