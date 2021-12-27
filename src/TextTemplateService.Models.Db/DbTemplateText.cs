using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LT.DigitalOffice.TextTemplateService.Models.Db
{
  public class DbTemplateText
  {
    public const string TableName = "TemplateTexts";

    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }

    public DbTemplate Template { get; set; }
  }

  public class DbTemplateTextConfiguration : IEntityTypeConfiguration<DbTemplateText>
  {
    public void Configure(EntityTypeBuilder<DbTemplateText> builder)
    {
      builder
        .ToTable(DbTemplateText.TableName);

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
        .WithMany(et => et.TemplateTexts);
    }
  }
}
