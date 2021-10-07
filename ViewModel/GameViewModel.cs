using System;
using System.ComponentModel.DataAnnotations;

namespace catalogo_jogos.ViewModel
{
    public class GameViewModel
    {
       
        [Required(ErrorMessage ="Name must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Producer must not be empty")]
        public string Producer { get; set; }
        [Required(ErrorMessage ="Price must not be empty")]
        public double Price { get; set; }
    }
}