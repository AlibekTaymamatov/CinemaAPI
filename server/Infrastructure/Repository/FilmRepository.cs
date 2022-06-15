namespace CleanArchitecture.Infra.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class FilmRepository : IFilmRepository
    {
        private DatabaseContext context;

        public FilmRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void DeleteFilm(int id)
        {
            try
            {
                var remoteObject = context.Film.Find(id);
                context.Film.Remove(remoteObject);
                context.SaveChanges();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public Film GetById(int id)
        {
            var data = context.Film.Find(id);
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return data;
        }

        public Film InsertFilm(Film film, List<int> genres)
        {
            var genreFilms = context.Genre.Where(e => genres.Contains(e.Id)).ToList();
            film.Genres = genreFilms;
            var entity = context.Add(film);
            context.SaveChanges();
            return entity.Entity;
        }

        public Film UpdateFilm(Film film, List<int> genre)
        {
            var data = context.Film.Find(film.Id);
            if (data == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                data.Id = film.Id;
                data.Name = film.Name;
                data.Poster = film.Poster;
                data.Description = film.Description;
                data.Duratuin = film.Duratuin;
                data.Rating = film.Rating;
                data.StartDate = film.StartDate;

                if (genre != null && genre.Count != 0)
                {
                    var genres = context.Genre.Where(a => genre.Contains(a.Id));
                    data.Genres.Clear();
                    genres.ForEachAsync(i => data.Genres.Add(i)).Wait();
                }
                else
                {
                    data.Genres.Clear();
                }

                context.SaveChanges();
            }

            return data;
        }

        IQueryable<Film> IFilmRepository.GetFilms()
        {
            var data = context.Film.AsNoTracking();
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return data;
        }
    }
}
