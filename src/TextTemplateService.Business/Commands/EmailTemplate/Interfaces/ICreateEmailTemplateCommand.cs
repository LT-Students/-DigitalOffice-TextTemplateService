using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.EmailTemplate.Interfaces
{
  [AutoInject]
  public interface ICreateEmailTemplateCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(EmailTemplateRequest request);
  }
}
