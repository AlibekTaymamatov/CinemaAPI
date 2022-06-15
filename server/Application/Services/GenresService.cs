namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Models;
    using Domain.Repository;

    public class GenresService : IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenresService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void DeleteGenre(int id)
        {
           _genreRepository.DeleteGenre(id);
        }

        public GenreDto GetById(int id)
        {
            var result = _genreRepository.GetById(id);
            return GenreMapper(result);
        }

        public List<GenreDto> GetGenres()
        {
            var genres = _genreRepository.GetGenre().Select(
                i => new GenreDto
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList();

            return genres;
        }

        public GenreDto InsertGenre(GenreCreateRequestDto genre)
        {
            var result = _genreRepository.InsertGenre(genre.ToModel());
            return GenreMapper(result);
        }

        public GenreDto UpdateGenre(GenreUpdateRequestDto genre)
        {
            var result = _genreRepository.UpdateGenre(genre.ToModel());
            return GenreMapper(result);
        }

        private GenreDto GenreMapper(Genre genre)
        {
            var data = new GenreDto();
            data.Id = genre.Id;
            data.Name = genre.Name;
            return data;
        }
    }
}