using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces
{
  [AutoInject]
  public interface IFindParseEntitiesCommand
  {
    Task<OperationResultResponse<Dictionary<string, Dictionary<string, List<string>>>>> ExecuteAsync();
  }
}
