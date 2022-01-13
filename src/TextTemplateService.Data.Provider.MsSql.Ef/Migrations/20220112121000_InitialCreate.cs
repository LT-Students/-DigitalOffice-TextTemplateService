using System;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef.Migrations
{
  [DbContext(typeof(TextTemplateServiceDbContext))]
  [Migration("20220112121000_InitialCreate")]
  public class InitialTables : Migration
  {
    protected override void Up(MigrationBuilder builder)
    {
      builder.CreateTable(
        name: DbTemplate.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          Name = table.Column<string>(nullable: false),
          Type = table.Column<int>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: true),
          CreatedAtUtc = table.Column<DateTime>(nullable: true),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbTemplate.TableName}", x => x.Id);
        });

      builder.CreateTable(
        name: DbTextTemplate.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          TemplateId = table.Column<Guid>(nullable: false),
          Subject = table.Column<string>(nullable: false),
          Text = table.Column<string>(nullable: false),
          Language = table.Column<string>(nullable: false, maxLength: 2),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbTextTemplate.TableName}", x => x.Id);
        });

      builder.CreateTable(
        name: DbEndpointTextTemplate.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          TextTemplateId = table.Column<Guid>(nullable: false),
          EndpointId = table.Column<Guid>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbEndpointTextTemplate.TableName}", p => p.Id);
        });

      builder.CreateTable(
        name: DbKeyword.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          EndpointId = table.Column<Guid>(nullable: false),
          Keyword = table.Column<string>(nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey($"PK_{DbKeyword.TableName}", p => p.Id);
        });
    }

    protected override void Down(MigrationBuilder builder)
    {
      builder.DropTable(
        name: DbTemplate.TableName);

      builder.DropTable(
        name: DbTextTemplate.TableName);

      builder.DropTable(
        name: DbEndpointTextTemplate.TableName);

      builder.DropTable(
        name: DbKeyword.TableName);
    }
  }
}

