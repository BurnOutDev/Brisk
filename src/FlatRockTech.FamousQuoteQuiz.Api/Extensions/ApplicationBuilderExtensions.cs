using Microsoft.AspNetCore.Builder;

namespace FlatRockTech.FamousQuoteQuiz.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            return applicationBuilder;
        }
    }
}
