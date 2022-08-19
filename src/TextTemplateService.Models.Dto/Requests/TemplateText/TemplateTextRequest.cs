using System;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText
{
  public record TemplateTextRequest
  {
    public Guid? TemplateId { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Locale { get; set; }
  }
}
