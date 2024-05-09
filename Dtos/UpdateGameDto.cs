using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string name,
    int genreId,
    [Range(1, 100)] decimal price,
    DateOnly releaseDate
);
