using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RoadAlertApi.Controllers;

public class DistinguishContentTypesFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var responseCopies = new Dictionary<string, OpenApiResponse>();

        foreach (var (statusCode, response) in operation.Responses)
        {
            foreach (var (contentType, mediaType) in response.Content)
            {
                var key = $"{statusCode} ({contentType})";

                // Create a new independent response object per content type
                responseCopies[key] = new OpenApiResponse
                {
                    Description = response.Description,
                    Content =
                    {
                        [contentType] = new OpenApiMediaType
                        {
                            Schema = mediaType.Schema,
                            Example = mediaType.Example,
                            Examples = mediaType.Examples
                        }
                    }
                };
            }
        }

        operation.Responses.Clear();

        foreach (var kvp in responseCopies)
        {
            operation.Responses[kvp.Key] = kvp.Value;
        }
    }
}