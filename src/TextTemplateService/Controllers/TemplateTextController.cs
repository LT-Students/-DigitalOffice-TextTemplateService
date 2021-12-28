using System;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Business.Commands.TemplateText.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.TextTemplateService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TemplateTextController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateTemplateTextCommand command,
      [FromBody] TemplateTextRequest request)
    {
      return await command.ExecuteAsync(request);
    }

    [HttpPatch("edit")]
    public async Task<OperationResultResponse<bool>> EditAsync(
      [FromServices] IEditTemplateTextCommand command,
      [FromQuery] Guid emailTemplateTextId,
      [FromBody] JsonPatchDocument<EditTemplateTextRequest> patch)
    {
      return await command.ExecuteAsync(emailTemplateTextId, patch);
    }
  }
}
