using System;
using System.Linq;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.Broker;
using LT.DigitalOffice.Models.Broker.Requests.TextTemplate;
using LT.DigitalOffice.Models.Broker.Responses.TextTemplate;
using LT.DigitalOffice.TextTemplateService.Data.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Db;
using MassTransit;

namespace LT.DigitalOffice.TextTemplateService.Broker.Consumers
{
  public class GetTextTemplateConsumer : IConsumer<IGetTextTemplateRequest>
  {
    private readonly IEndpointTemplateRepository _endpointTemplateRepository;
    private readonly ITemplateRepository _templateRepository;

    private async Task<object> GetTemplate(IGetTextTemplateRequest request)
    {
      DbTemplate dbTemplate = request.EndpointId.HasValue
        ? await _endpointTemplateRepository.GetAsync(request.EndpointId.Value)
        : await _templateRepository.GetAsync((int)request.TemplateType);

      DbTextTemplate dbTextTemplate = 
        dbTemplate.TextsTemplates.FirstOrDefault(tt => tt.Locale == request.Locale && tt.IsActive)
        ?? dbTemplate.TextsTemplates.FirstOrDefault(tt => tt.IsActive);

      return dbTextTemplate is null
        ? null
        : IGetTextTemplateResponse.CreateObj(
          dbTextTemplate.Id,
          dbTextTemplate.Subject,
          dbTextTemplate.Text,
          dbTextTemplate.Locale);
    }

    public GetTextTemplateConsumer(
      IEndpointTemplateRepository endpointTemplateRepository,
      ITemplateRepository templateRepository)
    {
      _endpointTemplateRepository = endpointTemplateRepository;
      _templateRepository = templateRepository;
    }

    public async Task Consume(ConsumeContext<IGetTextTemplateRequest> context)
    {
      Object result = OperationResultWrapper.CreateResponse(GetTemplate, context.Message);

      await context.RespondAsync<IOperationResult<IGetTextTemplateResponse>>(result);
    }
  }
}
