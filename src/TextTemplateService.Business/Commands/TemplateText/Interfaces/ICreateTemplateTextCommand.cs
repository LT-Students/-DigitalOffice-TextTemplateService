using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.TemplateText.Interfaces
{
  [AutoInject]
  public interface ICreateTemplateTextCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(TemplateTextRequest request);
  }
}
