using System;
using System.Threading.Tasks;
using LT.DigitalOffice.TextTemplateService.Business.Commands.Template.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.TextTemplateService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TemplateController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateTemplateCommand command,
      [FromBody] TemplateRequest request)
    {
      return await command.ExecuteAsync(request);
    }

    [HttpPatch("edit")]
    public async Task<OperationResultResponse<bool>> EditAsync(
      [FromServices] IEditTemplateCommand command,
      [FromQuery] Guid templateId,
      [FromBody] JsonPatchDocument<EditTemplateRequest> patch)
    {
      return await command.ExecuteAsync(templateId, patch);
    }

    [HttpGet("find")]
    public async Task<FindResultResponse<TemplateInfo>> FindAsync(
      [FromServices] IFindTemplateCommand command,
      [FromQuery] FindTemplateFilter filter)
    {
      return await command.ExecuteAsync(filter);
    }
  }
}
