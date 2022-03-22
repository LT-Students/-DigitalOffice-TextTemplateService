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
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Locale { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedAtUtc { get; set; }
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
        .HasKey(tt => tt.Id);

      builder
        .Property(tt => tt.Subject)
        .IsRequired();

      builder
        .Property(tt => tt.Locale)
        .IsRequired();

      builder
        .Property(tt => tt.Text)
        .IsRequired();

      builder
        .HasOne(tt => tt.Template)
        .WithMany(t => t.TextsTemplates);
    }
  }
}
