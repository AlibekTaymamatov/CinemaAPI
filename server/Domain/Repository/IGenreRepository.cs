namespace Domain.Repository
{
    using System.Linq;
    using Domain.Models;

    public interface IGenreRepository
    {
        IQueryable<Genre> GetGenre();

        Genre GetById(int id);

        Genre InsertGenre(Genre genre);

        Genre UpdateGenre(Genre genre);

        void DeleteGenre(int id);
    }
}
