namespace CleanArchitecture.Infra.Data.Repositories
{
    using System;
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class GenreRepository : IGenreRepository
    {
        private DatabaseContext context;

        public GenreRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void DeleteGenre(int id)
        {
            try
            {
                var remoteObject = context.Genre.Find(id);
                context.Genre.Remove(remoteObject);
                context.SaveChanges();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public Genre GetById(int id)
        {
            var data = context.Genre.Find(id);
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return data;
        }

        public Genre InsertGenre(Genre genre)
        {
            var entity = context.Add(genre);
            context.SaveChanges();
            return entity.Entity;
        }

        public Genre UpdateGenre(Genre genre)
        {
            var data = context.Genre.Find(genre.Id);
            if (data != null)
            {
                data.Name = genre.Name;
                data.Films = genre.Films;
                context.SaveChanges();
                return data;
            }

            throw new InvalidOperationException();
        }

        IQueryable<Genre> IGenreRepository.GetGenre()
        {
            var data = context.Genre.Include(x => x.Films).AsNoTracking();
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return data;
        }
    }
}
