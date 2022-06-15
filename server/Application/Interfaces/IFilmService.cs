namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IFilmService
    {
        List<FilmDto> GetFilms(FilmsParameters filmsParameters);

        FilmDto InsertFilm(FilmCreateRequestDto film);

        FilmDto UpdateFilm(FilmUpdateRequestDto film);

        void DeleteFilm(int id);

        FilmDto GetById(int id);
    }
}
