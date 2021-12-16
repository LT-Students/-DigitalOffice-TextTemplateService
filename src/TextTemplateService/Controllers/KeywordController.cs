using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Requests;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.ParseEntity;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.TextTemplateService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class KeywordController : ControllerBase
  {

    [HttpGet("FindParseEntities")]
    public async Task<OperationResultResponse<Dictionary<string, Dictionary<string, List<string>>>>> FindParseEntitiesAsync(
      [FromServices] IFindParseEntitiesCommand command)
    {
      return await command.ExecuteAsync();
    }

    [HttpGet("Find")]
    public async Task<FindResultResponse<KeywordInfo>> FindAsync(
      [FromServices] IFindKeywordCommand command,
      [FromQuery] BaseFindFilter filter)
    {
      return await command.ExecuteAsync(filter);
    }

    [HttpPost("Create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateKeywordCommand command,
      [FromBody] CreateKeywordRequest request)
    {
      return await command.ExecuteAsync(request);
    }
  }
}


