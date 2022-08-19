using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.Broker;
using LT.DigitalOffice.Kernel.EndpointSupport.Broker.Models.TextTemplate;
using LT.DigitalOffice.Kernel.EndpointSupport.Broker.Models.TextTemplate.Models;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Mappers.Db.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using MassTransit;

namespace LT.DigitalOffice.TextTemplateService.Broker.Consumers
{
  public class CreateKeywordsConsumer : IConsumer<ICreateKeywordsRequest>
  {
    private readonly IKeywordRepository _repository;
    private readonly IDbKeywordMapper _mapper;

    private async Task<bool> CreateKeywords(ICreateKeywordsRequest request)
    {
      List<DbKeyword> dbKeywords = await _repository
        .GetAsync(request.EndpointsKeywords.Select(x => x.EndpointId).ToList());

      List<DbKeyword> savedEndpointKeywords;
      List<string> newEndpointKeywords;
      List<DbKeyword> newDbKeywords = new();

      foreach (EndpointKeywords requestEndpointKeywords in request.EndpointsKeywords)
      {
        savedEndpointKeywords = dbKeywords
          .Where(dbk => requestEndpointKeywords.EndpointId == dbk.EndpointId)
          .ToList();

        newEndpointKeywords = savedEndpointKeywords.Any()
          ? requestEndpointKeywords.Keywords.Where(k => !savedEndpointKeywords.Select(dbk => dbk.Keyword).Contains(k)).ToList()
          : requestEndpointKeywords.Keywords;

        if (newEndpointKeywords.Any())
        {
          newDbKeywords.AddRange(_mapper.Map(requestEndpointKeywords.EndpointId, newEndpointKeywords));
        }
      }

      return await _repository.CreateAsync(newDbKeywords);
    }

    public CreateKeywordsConsumer(
      IKeywordRepository repository,
      IDbKeywordMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ICreateKeywordsRequest> context)
    {
      Object result = OperationResultWrapper.CreateResponse(CreateKeywords, context.Message);

      await context.RespondAsync<IOperationResult<bool>>(result);
    }
  }
}
