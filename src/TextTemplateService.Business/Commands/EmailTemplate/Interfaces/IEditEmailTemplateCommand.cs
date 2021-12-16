using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplate;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.EmailTemplate.Interfaces
{
  [AutoInject]
  public interface IEditEmailTemplateCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(
      Guid emailTemplateId,
      JsonPatchDocument<EditEmailTemplateRequest> patch);
  }
}
