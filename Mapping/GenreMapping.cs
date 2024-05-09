using GameStore.Api.Entities;

namespace GameStore.Api;

public static class GenreMapping
{
    public static GenreDto toDto(this Genre genre)
    {
        return new(genre.id, genre.name);
    }
}
