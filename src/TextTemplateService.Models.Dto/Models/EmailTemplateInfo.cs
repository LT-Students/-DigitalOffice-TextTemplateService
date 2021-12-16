using System;
using System.Collections.Generic;
using LT.DigitalOffice.Models.Broker.Enums;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Models
{
  public record EmailTemplateInfo
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EmailTemplateType Type { get; set; }
    public bool IsActive { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public List<EmailTemplateTextInfo> Texts { get; set; }
  }
}
