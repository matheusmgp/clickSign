using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SolAgora.External.ClickSign.Domain.ValueObject;

namespace SolAgora.External.ClickSign.Api.Filters;

public class ModelValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid)
        {
            await next();
            return;
        }

        var validationErrors = GetErrorsFromModelState(context.ModelState);
        var customErrorResponse = new CustomErrorResponse
        {
            Title = "Ocorreu um erro na validação",
            Errors = validationErrors
        };

        context.Result = new ObjectResult(customErrorResponse)
        {
            StatusCode = (int)HttpStatusCode.UnprocessableEntity
        };
    }

    private static Dictionary<string, string[]> GetErrorsFromModelState(ModelStateDictionary modelState)
    {
        var errors = new Dictionary<string, string[]>();

        foreach (var (key, value) in modelState.Where(x => x.Value!.Errors.Any()))
            errors.Add(key, value!.Errors.Select(e => e.ErrorMessage).ToArray());

        return errors;
    }
}
