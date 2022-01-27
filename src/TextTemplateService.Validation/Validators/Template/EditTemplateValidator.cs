using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using LT.DigitalOffice.Kernel.Validators;
using LT.DigitalOffice.Models.Broker.Enums;
using LT.DigitalOffice.TextTemplateService.Models.Dto.Requests.Template;
using LT.DigitalOffice.TextTemplateService.Validation.Validators.Template.Interfaces;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace LT.DigitalOffice.TextTemplateService.Validation.Validators.Template
{
  public class EditTemplateValidator : BaseEditRequestValidator<EditTemplateRequest>, IEditTemplateValidator
  {
    private void HandleInternalPropertyValidation(Operation<EditTemplateRequest> requestedOperation, CustomContext context)
    {
      Context = context;
      RequestedOperation = requestedOperation;

      #region Paths

      AddСorrectPaths(
        new List<string>
        {
          nameof(EditTemplateRequest.Name),
          nameof(EditTemplateRequest.Type),
          nameof(EditTemplateRequest.IsActive)
        });

      AddСorrectOperations(nameof(EditTemplateRequest.Name), new List<OperationType> { OperationType.Replace });
      AddСorrectOperations(nameof(EditTemplateRequest.Type), new List<OperationType> { OperationType.Replace });
      AddСorrectOperations(nameof(EditTemplateRequest.IsActive), new List<OperationType> { OperationType.Replace });

      #endregion

      #region Name

      AddFailureForPropertyIf(
        nameof(EditTemplateRequest.Name),
        x => x == OperationType.Replace,
        new()
        {
          { x => !string.IsNullOrEmpty(x.value?.ToString().Trim()), "Template name must not be empty." },
        });

      #endregion

      #region Type

      AddFailureForPropertyIf(
        nameof(EditTemplateRequest.Type),
        x => x == OperationType.Replace,
        new()
        {
          { x => Enum.TryParse(typeof(TemplateType), x.value.ToString(), true, out _), "Incorrect template type." },
        });

      #endregion

      #region IsActive

      AddFailureForPropertyIf(
        nameof(EditTemplateRequest.IsActive),
        x => x == OperationType.Replace,
        new()
        {
          { x => bool.TryParse(x.value?.ToString(), out _), "Incorrect is active value." },
        });

      #endregion
    }

    public EditTemplateValidator()
    {
      RuleForEach(x => x.Operations).Custom(HandleInternalPropertyValidation);
    }
  }
}
