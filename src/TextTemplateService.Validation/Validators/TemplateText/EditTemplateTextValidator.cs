using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using LT.DigitalOffice.Kernel.Validators;
using LT.DigitalOffice.TextTemplateService.Validation.Validators.TemplateText.Interfaces;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.TemplateText;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.EmailTemplateText
{
  public class EditTemplateTextValidator : BaseEditRequestValidator<EditTemplateTextRequest>, IEditTemplateTextValidator
  {
    private void HandleInternalPropertyValidation(Operation<EditTemplateTextRequest> requestedOperation, CustomContext context)
    {
      Context = context;
      RequestedOperation = requestedOperation;

      #region Paths

      AddСorrectPaths(
        new List<string>
        {
          nameof(EditTemplateTextRequest.Subject),
          nameof(EditTemplateTextRequest.Text),
          nameof(EditTemplateTextRequest.Locale)
        });

      AddСorrectOperations(nameof(EditTemplateTextRequest.Subject), new List<OperationType> { OperationType.Replace });
      AddСorrectOperations(nameof(EditTemplateTextRequest.Text), new List<OperationType> { OperationType.Replace });
      AddСorrectOperations(nameof(EditTemplateTextRequest.Locale), new List<OperationType> { OperationType.Replace });

      #endregion

      #region Subject

      AddFailureForPropertyIf(
        nameof(EditTemplateTextRequest.Subject),
        x => x == OperationType.Replace,
        new()
        {
          { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Subject must not be empty." },
        });

      #endregion

      #region Text

      AddFailureForPropertyIf(
        nameof(EditTemplateTextRequest.Text),
        x => x == OperationType.Replace,
        new()
        {
          { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Text must not be empty." },
        });

      #endregion

      #region Language

      AddFailureForPropertyIf(
        nameof(EditTemplateTextRequest.Locale),
        x => x == OperationType.Replace,
        new()
        {
          { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Language must not be empty." },
          { x => x.value.ToString().Trim().Length != 2, "Language must contain two letters." },
        }, CascadeMode.Stop);

      #endregion
    }

    public EditTemplateTextValidator()
    {
      RuleForEach(x => x.Operations).Custom(HandleInternalPropertyValidation);
    }
  }
}
