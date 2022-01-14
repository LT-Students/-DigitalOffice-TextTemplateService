using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces
{
  [AutoInject]
  public interface IGetEndpointKeywordsCommand
  {
    Task<OperationResultResponse<EndpointKeywordsInfo>> ExecuteAsync(Guid endpointId);
  }
}
