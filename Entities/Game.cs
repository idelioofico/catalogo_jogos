using System;
using System.ComponentModel.DataAnnotations;

namespace catalogo_jogos.Entities
{
    public class Game
    {

        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name must not be empty")]
        public string Name { get; set; }
        public string Producer { get; set; }
        [Required(ErrorMessage ="Price must not be empty")]
        public double Price { get; set; }
    }
}