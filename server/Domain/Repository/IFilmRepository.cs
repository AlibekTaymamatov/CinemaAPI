namespace Domain.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;

    public interface IFilmRepository
    {
        IQueryable<Film> GetFilms();

        Film GetById(int id);

        Film InsertFilm(Film film, List<int> genres);

        Film UpdateFilm(Film film, List<int> genres);

        void DeleteFilm(int id);
    }
}
