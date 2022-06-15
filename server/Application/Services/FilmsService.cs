namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Models;
    using Domain.Repository;

    public class FilmsService : IFilmService
    {
        private IFilmRepository _filmRepository;

        public FilmsService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void DeleteFilm(int id)
        {
            _filmRepository.DeleteFilm(id);
        }

        public FilmDto GetById(int id)
        {
            var film = _filmRepository.GetById(id);
            return FilmMapper(film, film.Genres.Select(x => x.Id).ToList());
        }

        public List<FilmDto> GetFilms(FilmsParameters filmsParameters)
        {
            var films = Filtering(filmsParameters, _filmRepository.GetFilms());
            films = SortingbyFilms(filmsParameters, films);

            var result = films.Skip((filmsParameters.PageNumber - 1) * filmsParameters.TotalPages)
                  .Take(filmsParameters.TotalPages).Select(
                i => new FilmDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Poster = i.Poster,
                    Description = i.Description,
                    Duratuin = i.Duratuin,
                    Rating = i.Rating,
                    StartDate = i.StartDate,
                    Genres = i.Genres.Select(j => j.Id).ToList(),
                }).ToList();

            return result;
        }

        public FilmDto InsertFilm(FilmCreateRequestDto film)
        {
            var modelFilm = film.ToModel();
            var filmResult = _filmRepository.InsertFilm(modelFilm, film.Genres);
            return FilmMapper(filmResult, filmResult.Genres.Select(x => x.Id).ToList());
        }

        public FilmDto UpdateFilm(FilmUpdateRequestDto film)
        {
            var modelFilm = film.ToModel();
            modelFilm.Genres = film.Genres.Select(i => new Genre { Id = i }).ToList();
            var filmUpdate = _filmRepository.UpdateFilm(modelFilm, film.Genres);
            return FilmMapper(filmUpdate, filmUpdate.Genres.Select(x => x.Id).ToList());
        }

        private FilmDto FilmMapper(Film film, List<int> genres)
        {
            var data = new FilmDto();
            data.Id = film.Id;
            data.Name = film.Name;
            data.Poster = film.Poster;
            data.Description = film.Description;
            data.Duratuin = film.Duratuin;
            data.Rating = film.Rating;
            data.StartDate = film.StartDate;
            data.Genres = genres;
            return data;
        }

        private IQueryable<Film> FilterRatingFilms(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            films = films.Where(o => o.Rating >= filmsParameters.MinRating && o.Rating <= filmsParameters.MaxRating);

            return films;
        }

        private IQueryable<Film> FilterGenresFilms(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            films = films.Where(y => y.Genres.Any(x => filmsParameters.GenreId.Contains(x.Id)));

            return films;
        }

        private IQueryable<Film> FilterNameFilms(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            films = films.Where(y => y.Name.Contains(filmsParameters.FilmName));

            return films;
        }

        private IQueryable<Film> FilterDurationFilms(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            films = films.Where(o => o.Duratuin >= filmsParameters.MinDuratuin && o.Duratuin <= filmsParameters.MaxDuratuin);

            return films;
        }

        private IQueryable<Film> Filtering(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            if (filmsParameters.MaxRating != 0 && filmsParameters.MinRating != 0)
            {
                films = FilterRatingFilms(filmsParameters, films);
            }

            if (filmsParameters.MinDuratuin != 0 && filmsParameters.MaxDuratuin != 0)
            {
                films = FilterDurationFilms(filmsParameters, films);
            }

            if (filmsParameters.GenreId != null)
            {
                films = FilterGenresFilms(filmsParameters, films);
            }

            if (filmsParameters.FilmName != null)
            {
                films = FilterNameFilms(filmsParameters, films);
            }

            return films;
        }

        private IQueryable<Film> SortingbyFilms(FilmsParameters filmsParameters, IQueryable<Film> films)
        {
            switch (filmsParameters.SortingByFilms)
            {
                case "name":
                    if (filmsParameters.SortOrder == Sorting.ASC)
                    {
                        films = films.OrderBy(x => x.Name);
                    }
                    else
                    {
                        films = films.OrderByDescending(x => x.Name);
                    }

                    break;

                case "rating":

                    if (filmsParameters.SortOrder == Sorting.ASC)
                    {
                        films = films.OrderBy(x => x.Rating);
                    }
                    else
                    {
                        films = films.OrderByDescending(x => x.Rating);
                    }

                    break;

                case "genre":

                    if (filmsParameters.SortOrder == Sorting.ASC)
                    {
                        films = films.OrderBy(x => x.Genres);
                    }
                    else
                    {
                        films = films.OrderByDescending(x => x.Genres);
                    }

                    break;

                case "duration":
                    if (filmsParameters.SortOrder == Sorting.ASC)
                    {
                        films = films.OrderBy(x => x.Duratuin);
                    }
                    else
                    {
                        films = films.OrderByDescending(x => x.Duratuin);
                    }

                    break;

                case "":
                    films = films.OrderBy(x => x.Id);

                    break;
            }

            return films;
        }
    }
}