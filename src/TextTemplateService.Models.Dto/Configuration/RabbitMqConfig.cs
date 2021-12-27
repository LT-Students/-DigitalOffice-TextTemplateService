using System.Collections.Generic;
using LT.DigitalOffice.Kernel.BrokerSupport.Configurations;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Configuration
{
  public class RabbitMqConfig : BaseRabbitMqConfig
  {
    public Dictionary<string, string> FindUserParseEntitiesEndpoint { get; set; }
    public string CreateKeywordsEndpoint { get; set; }
  }
}
