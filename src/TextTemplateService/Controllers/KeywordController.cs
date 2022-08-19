using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;
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

    [HttpGet("get")]
    public async Task<OperationResultResponse<EndpointKeywordsInfo>> GetAsync(
      [FromServices] IGetEndpointKeywordsCommand command,
      [FromQuery] Guid endpointId)
    {
      return await command.ExecuteAsync(endpointId);
    }
  }
}

