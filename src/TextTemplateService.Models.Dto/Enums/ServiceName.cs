using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Enums
{
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ServiceName
  {
    UserService,
    ProjectService
  }
}
