using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.Template.Interfaces
{
  [AutoInject]
  public interface IFindTemplateCommand
  {
    Task<FindResultResponse<TemplateInfo>> ExecuteAsync(FindTemplateFilter filter);
  }
}
