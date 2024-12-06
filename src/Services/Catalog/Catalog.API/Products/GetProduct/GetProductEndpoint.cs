﻿namespace Catalog.API.Products.GetProduct;
public record GetProductResponse(List<Product> products);

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductResponse>();

                return Results.Ok(response);

            }).WithName("GetProducts")
         .Produces<GetProductResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .WithSummary("Get Products")
         .WithDescription("Get Products");
    }
}