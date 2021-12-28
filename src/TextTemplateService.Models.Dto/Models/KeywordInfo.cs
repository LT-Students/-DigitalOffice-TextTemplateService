using System;
using LT.DigitalOffice.Models.Broker.Enums;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Models
{
  public record KeywordInfo
  {
    public Guid Id { get; set; }
    public string Service { get; set; }
    public string EntityName { get; set; }
    public string Keyword { get; set; }
  }
}
