using LT.DigitalOffice.Kernel.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template
{
  public record FindTemplateFilter : BaseFindFilter
  {
    [FromQuery(Name = "includedeactivated")]
    public bool IncludeDeactivated { get; set; } = false;
  }
}
