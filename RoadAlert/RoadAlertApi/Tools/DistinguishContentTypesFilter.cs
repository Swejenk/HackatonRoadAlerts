using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RoadAlertApi.Tools;

public sealed class ProducesContentSchemaFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attrs = context.MethodInfo
            .GetCustomAttributes(typeof(ProducesContentSchemaAttribute), true)
            .Cast<ProducesContentSchemaAttribute>()
            .ToList();

        if (attrs.Count == 0) return;

        foreach (var a in attrs)
        {
            var key = a.StatusCode.ToString();
            if (!operation.Responses.TryGetValue(key, out var response)) continue;

            if (!response.Content.TryGetValue(a.ContentType, out var media))
            {
                media = new OpenApiMediaType();
                response.Content[a.ContentType] = media;
            }

            media.Schema = context.SchemaGenerator.GenerateSchema(a.Type, context.SchemaRepository);
        }
    }
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ProducesContentSchemaAttribute(Type type, int statusCode, string contentType) : Attribute
{
    public int StatusCode { get; } = statusCode;
    public string ContentType { get; } = contentType;
    public Type Type { get; } = type;
}