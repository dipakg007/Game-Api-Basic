using GameStore.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api;

public static class GenreEndpoints
{
    [HttpGet]
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.genres
                            .Select(genre => genre.toDto())
                            .AsNoTracking()
                            .ToListAsync();
        });

        return group;
    }
}
