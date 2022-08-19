using LT.DigitalOffice.Models.Broker.Enums;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template
{
  public record EditTemplateRequest
  {
    public string Name { get; set; }
    public TemplateType Type { get; set; }
    public bool IsActive { get; set; }
  }
}
