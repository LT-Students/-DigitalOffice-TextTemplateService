using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Constants;
using LT.DigitalOffice.Kernel.Enums;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity
{
  public class FindServiceKeywordsCommand : IFindServiceKeywordsCommand
  {
    private readonly IAccessValidator _accessValidator;
    private readonly IKeywordRepository _repository;
    private readonly IKeywordInfoMapper _mapper;
    private readonly IResponseCreator _responseCreator;

    public FindServiceKeywordsCommand(
      IAccessValidator accessValidator,
      IKeywordRepository repository,
      IKeywordInfoMapper mapper,
      IResponseCreator responseCreator)
    {
      _accessValidator = accessValidator;
      _repository = repository;
      _mapper = mapper;
      _responseCreator = responseCreator;
    }

    public async Task<FindResultResponse<KeywordInfo>> ExecuteAsync(SourceKeywords service)
    {
      if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveEmailTemplates))
      {
        return _responseCreator.CreateFailureFindResponse<KeywordInfo>(HttpStatusCode.Forbidden);
      }

      return new()
      {
        Status = OperationResultStatusType.FullSuccess,
        Body = (await _repository.GetAsync((int)service)).Select(_mapper.Map).ToList()
      };
    }
  }
}

