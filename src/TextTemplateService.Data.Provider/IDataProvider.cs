using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Database;
using LT.DigitalOffice.Kernel.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider
{
  [AutoInject(InjectType.Scoped)]
  public interface IDataProvider : IBaseDataProvider
  {
    DbSet<DbTemplate> Templates { get; set; }
    DbSet<DbTextTemplate> TextTemplates { get; set; }
    DbSet<DbKeyword> Keywords { get; set; }
  }
}
