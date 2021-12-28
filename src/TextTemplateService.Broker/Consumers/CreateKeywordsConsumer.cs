using System;
using System.Linq;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.Broker;
using LT.DigitalOffice.Models.Broker.Requests.TextTemplate;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using MassTransit;

namespace LT.DigitalOffice.TextTemplateService.Broker.Consumers
{
  public class CreateKeywordsConsumer : IConsumer<ICreateKeywordsRequest>
  {
    private readonly IKeywordRepository _repository;
    private async Task<object> CreateKeywords(ICreateKeywordsRequest request)
    {
      await _repository.CreateAsync(request.KeywordsTables.SelectMany(kt =>
      kt.Keywords.Select(k => new DbKeyword()
      {
        Id = Guid.NewGuid(),
        Service = (int)request.Source,
        EntityName = kt.TableName,
        Keyword = k
      }).ToList()).ToList(), (int)request.Source);

      return true;
    }

    public CreateKeywordsConsumer(
      IKeywordRepository repository)
    {
      _repository = repository;
    }
    public async Task Consume(ConsumeContext<ICreateKeywordsRequest> context)
    {
      Object result = OperationResultWrapper.CreateResponse(CreateKeywords, context.Message);

      await context.RespondAsync<IOperationResult<bool>>(result);
    }
  }
}
