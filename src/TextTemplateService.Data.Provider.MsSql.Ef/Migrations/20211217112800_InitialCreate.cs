using System;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef.Migrations
{
  [DbContext(typeof(TextTemplateServiceDbContext))]
  [Migration("20211217112800_InitialCreate")]
  public class InitialTables : Migration
  {
    protected override void Up(MigrationBuilder builder)
    {
      builder.CreateTable(
        name: DbEmailTemplate.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          Name = table.Column<string>(nullable: false),
          Type = table.Column<int>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbEmailTemplate.TableName}", x => x.Id);
        });

      builder.CreateTable(
        name: DbEmailTemplateText.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          EmailTemplateId = table.Column<Guid>(nullable: false),
          Subject = table.Column<string>(nullable: false),
          Text = table.Column<string>(nullable: false),
          Language = table.Column<string>(nullable: false, maxLength: 2)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbEmailTemplateText.TableName}", x => x.Id);
        });

      builder.CreateTable(
        name: DbKeyword.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          Keyword = table.Column<string>(nullable: false, maxLength: 50),
          ServiceName = table.Column<int>(nullable: false),
          EntityName = table.Column<string>(nullable: false),
          PropertyName = table.Column<string>(nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Keyword", p => p.Id);
          table.UniqueConstraint("UC_Keyword", p => p.Keyword);
        });
    }

    protected override void Down(MigrationBuilder builder)
    {
      builder.DropTable(
        name: DbEmailTemplate.TableName);

      builder.DropTable(
        name: DbEmailTemplateText.TableName);

      builder.DropTable(
        name: DbKeyword.TableName);
    }
  }
}

