using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LT.DigitalOffice.TextTemplateService.Models.Db;
public class DbEndpointTemplate
{
  public const string TableName = "EndpointsTemplates";

  public Guid Id { get; set; }
  public Guid TemplateId { get; set; }
  public Guid EndpointId { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }

  public DbTemplate Template { get; set; }

  public DbEndpointTemplate()
  {
    Template = new DbTemplate();
  }
}

public class DbEndpointTemplateConfiguration : IEntityTypeConfiguration<DbEndpointTemplate>
{
  public void Configure(EntityTypeBuilder<DbEndpointTemplate> builder)
  {
    builder
      .ToTable(DbEndpointTemplate.TableName);

    builder
      .HasKey(pe => pe.Id);

    builder
      .HasOne(et => et.Template)
      .WithMany(t => t.Endpoints);
  }
}

