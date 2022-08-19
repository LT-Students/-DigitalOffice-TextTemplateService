namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText
{
  public record EditTemplateTextRequest
  {
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Locale { get; set; }
  }
}
