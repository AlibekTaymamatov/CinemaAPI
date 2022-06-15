namespace Application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Models;

    public class FilmDto
    {
        public FilmDto(Film film)
        {
            this.Id = film.Id;
            this.Name = film.Name;
            this.Poster = film.Poster;
            this.Description = film.Description;
            this.Duratuin = film.Duratuin;
            this.Rating = film.Rating;
            this.StartDate = film.StartDate;
        }

        public FilmDto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Poster { get; set; }

        public string Description { get; set; }

        public int Duratuin { get; set; }

        public double Rating { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        public List<int> Genres { get; set; } = new List<int>();
    }
}
