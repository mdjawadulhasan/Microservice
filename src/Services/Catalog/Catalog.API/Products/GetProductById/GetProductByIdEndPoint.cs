﻿
namespace Catalog.API.Products.GetProductById;

public record GetProductByIdResponse(Product Products);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        })
         .WithName("GetProductsById")
         .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .WithSummary("Get Product By Id")
         .WithDescription("Get Product By Id");
    }
}
