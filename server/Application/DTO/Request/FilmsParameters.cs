namespace Application.DTO.Request
{
    using System.Collections.Generic;

    public enum Sorting
    {
        ASC,
        DESC,
    }

    public class FilmsParameters : RangePage
    {
        public double MinRating { get; set; } = 0.0;

        public double MaxRating { get; set; } = 10.0;

        public List<int> GenreId { get; set; }

        public bool ValidRatingRange => MaxRating > MinRating;

        public string FilmName { get; set; }

        public int MaxDuratuin { get; set; }

        public int MinDuratuin { get; set; }

        public bool ValidDuratuinRange => MaxDuratuin > MinDuratuin;

        public Sorting SortOrder { get; set; }

        public string SortingByFilms { get; set; }
    }
}
