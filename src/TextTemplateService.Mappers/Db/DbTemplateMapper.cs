﻿using System;
using System.Linq;
using LT.DigitalOffice.Kernel.Extensions;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using Microsoft.AspNetCore.Http;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Db
{
  public class DbTemplateMapper : IDbTemplateMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDbTemplateTextMapper _dbEmailTemplateTextMapper;

    public DbTemplateMapper(
      IHttpContextAccessor httpContextAccessor,
      IDbTemplateTextMapper dbEmailTemplateTextMapper)
    {
      _httpContextAccessor = httpContextAccessor;
      _dbEmailTemplateTextMapper = dbEmailTemplateTextMapper;
    }

    public DbTemplate Map(TemplateRequest request)
    {
      if (request == null)
      {
        return null;
      }

      var templateId = Guid.NewGuid();

      return new DbTemplate
      {
        Id = templateId,
        Name = request.Name,
        Type = (int)request.Type,
        IsActive = true,
        CreatedAtUtc = DateTime.UtcNow,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        TemplateTexts = request.TemplateTexts
          .Select(x => _dbEmailTemplateTextMapper.Map(x, templateId))
          .ToList()
      };
    }
  }
}