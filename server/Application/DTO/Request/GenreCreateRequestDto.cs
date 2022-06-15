namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class GenreCreateRequestDto : IDtoMapper<Genre>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Genre ToModel()
        {
            return new Genre()
            {
                Name = this.Name,
            };
        }
    }
}
