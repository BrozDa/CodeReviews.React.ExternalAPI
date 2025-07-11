﻿using Cars.API.Data;
using Cars.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Endpoints
{
    public static class CarEndpoints
    {

        public static IEndpointRouteBuilder AddCarEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/cars");

            group.MapGet("/", async (CarContext dbContext) =>
            {

                var result = await dbContext.Cars.AsNoTracking()
                                                .OrderBy(c => c.Name)
                                                .Select(c => new CarBrief(c.Id, c.Name, c.ImageUrl))
                                                .ToListAsync();
                return Results.Ok(result);
            })
            .Produces<List<CarBrief>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound); 

            group.MapGet("/{id:Guid}", async (Guid id, CarContext dbContext) =>
            {
                var result = await dbContext.Cars.FindAsync(id);

                return (result is not null)
                ? Results.Ok(result)
                : Results.NotFound();
            })
            .Produces<List<CarDetail>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            return builder;
        }
    }
}
