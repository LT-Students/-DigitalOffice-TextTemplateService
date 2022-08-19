using System;
using System.Collections.Generic;
using LT.DigitalOffice.Models.Broker.Enums;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Models
{
  public record TemplateInfo
  {
    public Guid Id { get; set; }
    public TemplateType Type { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
    public List<TemplateTextInfo> Texts { get; set; }
  }
}
