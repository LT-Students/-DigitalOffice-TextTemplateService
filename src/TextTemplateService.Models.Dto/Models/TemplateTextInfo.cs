using System;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Models
{
  public record TemplateTextInfo
  {
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Locale { get; set; }
  }
}
