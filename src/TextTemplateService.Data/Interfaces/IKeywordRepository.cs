﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Requests;
using LT.DigitalOffice.TextTemplateService.Models.Db;

namespace LT.DigitalOffice.TextTemplateService.Data.Interfaces
{
  [AutoInject]
  public interface IKeywordRepository
  {
    Task<Guid?> CreateAsync(DbKeyword request);

    Task<DbKeyword> GetAsync(Guid entityId);

    Task<(List<DbKeyword> dbKeywords, int totalCount)> FindAsync(BaseFindFilter filter);

    Task<bool> RemoveAsync(Guid entityId);

    Task<bool> DoesKeywordExistAsync(string keyword);
  }
}
