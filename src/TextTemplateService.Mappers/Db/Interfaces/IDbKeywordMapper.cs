using System;
using System.Collections.Generic;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.TextTemplateService.Models.Db;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbKeywordMapper
  {
    List<DbKeyword> Map(Guid endpointId, List<string> keywords);
  }
}
