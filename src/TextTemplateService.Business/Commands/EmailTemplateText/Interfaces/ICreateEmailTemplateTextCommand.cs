using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.EmailTemplateText.Interfaces
{
  [AutoInject]
  public interface ICreateEmailTemplateTextCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(EmailTemplateTextRequest request);
  }
}
