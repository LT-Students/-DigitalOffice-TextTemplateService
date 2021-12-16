using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.ParseEntity;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces
{
  [AutoInject]
  public interface ICreateKeywordCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateKeywordRequest request);
  }
}
