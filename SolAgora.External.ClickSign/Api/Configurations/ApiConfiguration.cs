using FluentValidation;
using FluentValidation.AspNetCore;
using SolAgora.External.ClickSign.Api.Filters;

namespace SolAgora.External.ClickSign.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services
            .AddControllers(options => options.Filters.Add(new ModelValidationActionFilter()))
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        services.AddFluentValidationAutoValidation(c =>
        {
            c.DisableDataAnnotationsValidation = true;
        });
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }
}
