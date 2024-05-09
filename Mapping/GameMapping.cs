using GameStore.Api.Dtos;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game toEntity(this CreateGameDto gameDto)
    {
        return new()
        {
            name = gameDto.name,
            genreId = gameDto.genreId,
            price = gameDto.price,
            releaseDate = gameDto.releaseDate
        };
    }

    public static Game toEntity(this UpdateGameDto gameDto, int id)
    {
        return new()
        {
            id = id,
            name = gameDto.name,
            genreId = gameDto.genreId,
            price = gameDto.price,
            releaseDate = gameDto.releaseDate
        };
    }

    public static GameSuammryDto toSummaryDto(this Game game)
    {
        return new(
                game.id,
                game.name,
                game.genre!.name,
                game.price,
                game.releaseDate
            );
    }

    public static GameDetailsDto toDetailsDto(this Game game)
    {
        return new(
                game.id,
                game.name,
                game.genreId,
                game.price,
                game.releaseDate
            );
    }
}
