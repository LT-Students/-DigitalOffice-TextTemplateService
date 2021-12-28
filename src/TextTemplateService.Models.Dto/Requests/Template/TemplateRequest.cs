using System.Collections.Generic;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template
{
  public record TemplateRequest
  {
    public string Name { get; set; }
    public EmailTemplateType Type { get; set; }
    public List<TemplateTextRequest> TemplateTexts { get; set; }
  }
}
