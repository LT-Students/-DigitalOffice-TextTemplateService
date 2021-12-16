using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;
using Microsoft.AspNetCore.JsonPatch;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.EmailTemplateText.Interfaces
{
  [AutoInject]
  public interface IEditEmailTemplateTextCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(
      Guid emailTemplateTextId,
      JsonPatchDocument<EditEmailTemplateTextRequest> patch);
  }
}
