using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LT.DigitalOffice.TextTemplateService.Models.Db
{
  public class DbTextTemplate
  {
    public const string TableName = "TextsTemplates";

    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public bool IsActive { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbTemplate Template { get; set; }
  }

  public class DbTextTemplateConfiguration : IEntityTypeConfiguration<DbTextTemplate>
  {
    public void Configure(EntityTypeBuilder<DbTextTemplate> builder)
    {
      builder
        .ToTable(DbTextTemplate.TableName);

      builder
        .HasKey(ett => ett.Id);

      builder
        .Property(ett => ett.Subject)
        .IsRequired();

      builder
        .Property(ett => ett.Language)
        .IsRequired();

      builder
        .Property(ett => ett.Text)
        .IsRequired();

      builder
        .HasOne(ett => ett.Template)
        .WithMany(et => et.TextsTemplates);
    }
  }
}
