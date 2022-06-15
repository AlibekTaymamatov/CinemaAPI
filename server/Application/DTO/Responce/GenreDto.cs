namespace Application.ViewModels
{
    using Domain.Models;

    public class GenreDto
    {
        public GenreDto(Genre film)
        {
            this.Id = film.Id;
            this.Name = film.Name;
        }

        public GenreDto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
