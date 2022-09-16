using System;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider.MsSql.Ef.Migrations
{
  [Migration("20220916160811_AddEmptyUserWorktimesText")]
  [DbContext(typeof(TextTemplateServiceDbContext))]
  public class AddEmptyUserWorktimesText : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      Guid EmptyUserWorktimesTemplate = Guid.NewGuid();

      const string ru = "ru";

      migrationBuilder.InsertData(
        table: DbTemplate.TableName,
        columns: new[]
        {
          nameof(DbTemplate.Id),
          nameof(DbTemplate.Type),
          nameof(DbTemplate.IsActive)
        },
        columnTypes: new string[]
        {
          "uniqueidentifier",
          "int",
          "bit"
        },
        values: new object[,]
        {
          { EmptyUserWorktimesTemplate, (int)TemplateType.EmptyUserWorktimes, true }
        });

      migrationBuilder.InsertData(
        table: DbTextTemplate.TableName,
        columns: new[]
        {
          nameof(DbTextTemplate.Id),
          nameof(DbTextTemplate.TemplateId),
          nameof(DbTextTemplate.Name),
          nameof(DbTextTemplate.Subject),
          nameof(DbTextTemplate.Text),
          nameof(DbTextTemplate.Locale),
          nameof(DbTextTemplate.IsActive)
        },
        columnTypes: new string[]
        {
          "uniqueidentifier",
          "uniqueidentifier",
          "nvarchar(MAX)",
          "nvarchar(MAX)",
          "nvarchar(MAX)",
          "nvarchar(2)",
          "bit"
        },
        values: new object[,]
        {
          {
            Guid.NewGuid(),
            EmptyUserWorktimesTemplate,
            "Напоминание сотрудникам о внесении часов",
            "Напоминание сотрудникам о внесении часов",
            "Здравствуйте, {[FirstName]} {[LastName]}!\n"
            + "Не забудьте внести свои рабочие часы с {[FirstLastMonth]} по {[LastLastMonth]} "
            + "до {[LastCurrentMonth]} "
            + "на странице учёта времени: https://ltdo.xyz/time",
            ru,
            true
          }
        });
    }
  }
}
