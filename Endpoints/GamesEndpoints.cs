using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.games
                            .Include(game => game.genre)
                            .Select(game => game.toSummaryDto())
                            .AsNoTracking()
                            .ToListAsync();
        });

        // GET /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.toDetailsDto());
        }).WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.toEntity();

            dbContext.games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.id }, game.toDetailsDto());
        });

        // PUT /games/1
        group.MapPut("/{id}", async (int id, UpdateGameDto updateGameDto, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.games.FindAsync(id);
            if (existingGame == null) return Results.NotFound();
            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updateGameDto.toEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // Delete /games/1
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.games.Where(game => game.id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }

}
