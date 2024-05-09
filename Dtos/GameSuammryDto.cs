namespace GameStore.Api.Dtos;

public record class GameSuammryDto(int id, string name, string genre, decimal price, DateOnly releaseDate);
