using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Business.Commands.EmailTemplateText.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.EmailTemplateText;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.TextTemplateService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class EmailTemplateTextController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateEmailTemplateTextCommand command,
      [FromBody] EmailTemplateTextRequest request)
    {
      return await command.ExecuteAsync(request);
    }

    [HttpPatch("edit")]
    public async Task<OperationResultResponse<bool>> EditAsync(
      [FromServices] IEditEmailTemplateTextCommand command,
      [FromQuery] Guid emailTemplateTextId,
      [FromBody] JsonPatchDocument<EditEmailTemplateTextRequest> patch)
    {
      return await command.ExecuteAsync(emailTemplateTextId, patch);
    }
  }
}


