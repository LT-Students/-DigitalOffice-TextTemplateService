using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LT.DigitalOffice.TextTemplateService.Models.Db
{
  public class DbTemplate
  {
    public const string TableName = "Templates";

    public Guid Id { get; set; }
    public int Type { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public ICollection<DbEndpointTemplate> Endpoints { get; set; }
    public ICollection<DbTextTemplate> TextsTemplates { get; set; }

    public DbTemplate()
    {
      Endpoints = new HashSet<DbEndpointTemplate>();
      TextsTemplates = new HashSet<DbTextTemplate>();
    }
  }

  public class DbTemplateConfiguration : IEntityTypeConfiguration<DbTemplate>
  {
    public void Configure(EntityTypeBuilder<DbTemplate> builder)
    {
      builder
        .ToTable(DbTemplate.TableName);

      builder
        .HasKey(et => et.Id);

      builder
        .HasMany(et => et.TextsTemplates)
        .WithOne(et => et.Template);
    }
  }
}
