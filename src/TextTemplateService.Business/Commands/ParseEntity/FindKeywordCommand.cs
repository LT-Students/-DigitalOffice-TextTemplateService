using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Constants;
using LT.DigitalOffice.Kernel.Enums;
using LT.DigitalOffice.Kernel.FluentValidationExtensions;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Requests;
using LT.DigitalOffice.Kernel.Responses;
using LT.DigitalOffice.Kernel.Validators.Interfaces;
using LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity.Interfaces;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Mappers.Models.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Models;

namespace LT.DigitalOffice.TextTemplateService.Business.Commands.ParseEntity
{
  public class FindKeywordCommand : IFindKeywordCommand
  {
    private readonly IAccessValidator _accessValidator;
    private readonly IBaseFindFilterValidator _baseFindValidator;
    private readonly IKeywordRepository _repository;
    private readonly IKeywordInfoMapper _mapper;
    private readonly IResponseCreator _responseCreator;

    public FindKeywordCommand(
      IAccessValidator accessValidator,
      IBaseFindFilterValidator baseFindValidator,
      IKeywordRepository repository,
      IKeywordInfoMapper mapper,
      IResponseCreator responseCreator)
    {
      _accessValidator = accessValidator;
      _baseFindValidator = baseFindValidator;
      _repository = repository;
      _mapper = mapper;
      _responseCreator = responseCreator;
    }

    public async Task<FindResultResponse<KeywordInfo>> ExecuteAsync(BaseFindFilter filter)
    {
      if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveEmailTemplates))
      {
        return _responseCreator.CreateFailureFindResponse<KeywordInfo>(HttpStatusCode.Forbidden);
      }

      if (!_baseFindValidator.ValidateCustom(filter, out List<string> errors))
      {
        return _responseCreator.CreateFailureFindResponse<KeywordInfo>(
          HttpStatusCode.BadRequest,
          errors);
      }

      (List<DbKeyword> dbKeywords, int totalCount) repositoryResponse = await _repository.FindAsync(filter);

      return new()
      {
        Status = OperationResultStatusType.FullSuccess,
        Body = repositoryResponse.dbKeywords?.Select(_mapper.Map).ToList(),
        TotalCount = repositoryResponse.totalCount
      };
    }
  }
}

