namespace Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}