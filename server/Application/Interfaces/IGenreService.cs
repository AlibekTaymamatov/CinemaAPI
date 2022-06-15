namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IGenreService
    {
        List<GenreDto> GetGenres();

        GenreDto InsertGenre(GenreCreateRequestDto genre);

        GenreDto UpdateGenre(GenreUpdateRequestDto genre);

        void DeleteGenre(int id);

        GenreDto GetById(int id);
    }
}
