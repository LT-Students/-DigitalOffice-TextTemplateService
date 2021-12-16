﻿using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Database;
using LT.DigitalOffice.Kernel.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.TextTemplateService.Data.Provider
{
  [AutoInject(InjectType.Scoped)]
  public interface IDataProvider : IBaseDataProvider
  {
    DbSet<DbEmailTemplate> EmailTemplates { get; set; }
    DbSet<DbEmailTemplateText> EmailTemplateTexts { get; set; }
    DbSet<DbKeyword> ParseEntities { get; set; }
  }
}
