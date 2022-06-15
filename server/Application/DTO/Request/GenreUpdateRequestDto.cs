namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class GenreUpdateRequestDto : IDtoMapper<Genre>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Genre ToModel()
        {
            return new Genre()
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}
