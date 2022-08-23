namespace GestioneSagre.Core.Customizations.Swagger;

public class DefaultResponseOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Responses.TryAdd("default", GetResponse("Error"));
    }

    public static OpenApiResponse GetResponse(string description)
        => new()
        {
            Description = description,
            Content = new Dictionary<string, OpenApiMediaType>
            {
                [MediaTypeNames.Application.Json] = new()
                {
                    Schema = new()
                    {
                        Reference = new()
                        {
                            Id = nameof(ProblemDetails),
                            Type = ReferenceType.Schema
                        }
                    }
                }
            }
        };
}
