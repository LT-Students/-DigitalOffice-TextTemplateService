using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Models
{
  public record EndpointKeywordsInfo
  {
    public Guid EndpointId { get; set; }
    public List<string> Keywords { get; set; }
  }
}
