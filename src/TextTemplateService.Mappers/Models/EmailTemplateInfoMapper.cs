using System.Linq;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Mappers.Models
{
  public class EmailTemplateInfoMapper : IEmailTemplateInfoMapper
  {
    private readonly IEmailTemplateTextInfoMapper _mapper;

    public EmailTemplateInfoMapper(
      IEmailTemplateTextInfoMapper mapper)
    {
      _mapper = mapper;
    }

    public EmailTemplateInfo Map(DbEmailTemplate dbEmailTemplate)
    {
      if (dbEmailTemplate == null)
      {
        return null;
      }

      return new EmailTemplateInfo
      {
        Id = dbEmailTemplate.Id,
        Name = dbEmailTemplate.Name,
        Type = (EmailTemplateType)dbEmailTemplate.Type,
        IsActive = dbEmailTemplate.IsActive,
        CreatedBy = dbEmailTemplate.CreatedBy,
        CreatedAtUtc = dbEmailTemplate.CreatedAtUtc,
        Texts = dbEmailTemplate.EmailTemplateTexts?
          .Select(_mapper.Map)
          .ToList()
      };
    }
  }
}
