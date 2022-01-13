using System;

namespace LT.DigitalOffice.TextTemplateService.Models.Db;
public class DbEndpointTextTemplate
{
  public const string TableName = "EndpointsTextTemplates";

  public Guid Id { get; set; }
  public Guid TemplateId { get; set; }
  public Guid EndpointId { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }
}

