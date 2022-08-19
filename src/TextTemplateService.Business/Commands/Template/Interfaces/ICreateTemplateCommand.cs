using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.Template.Interfaces
{
  [AutoInject]
  public interface ICreateTemplateCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(TemplateRequest request);
  }
}
