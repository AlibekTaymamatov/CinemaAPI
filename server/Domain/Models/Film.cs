namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Film
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

        public virtual ICollection<Genre> Genres { get; set; }
    }
}