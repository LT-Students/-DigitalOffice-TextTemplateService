using System.Collections.Generic;
using System.Linq;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class EndpointKeywordsInfoMapper : IEndpointKeywordsInfoMapper
  {
    public EndpointKeywordsInfo Map(List<DbKeyword> dbKeywords)
    {
      if (dbKeywords is null || !dbKeywords.Any())
      {
        return default;
      }

      return new EndpointKeywordsInfo
      {
        EndpointId = dbKeywords.FirstOrDefault().EndpointId,
        Keywords = dbKeywords.Select(k => k.Keyword).ToList()
      };
    }
  }
}
