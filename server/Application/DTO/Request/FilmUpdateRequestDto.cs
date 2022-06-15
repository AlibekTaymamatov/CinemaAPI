namespace Application.DTO.Request
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Application.Interfaces;
    using Domain.Models;

    public class FilmUpdateRequestDto : IDtoMapper<Film>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        [MaxLength(350)]
        public string Description { get; set; }

        [Required]
        public int Duratuin { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        public List<int> Genres { get; set; } = new List<int>();

        public Film ToModel()
        {
            return new Film()
            {
                Id = this.Id,
                Name = this.Name,
                Poster = this.Poster,
                Description = this.Description,
                Duratuin = this.Duratuin,
                Rating = this.Rating,
                StartDate = this.StartDate,
            };
        }
    }
}
