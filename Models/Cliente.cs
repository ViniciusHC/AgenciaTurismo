using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome não pode possuir menos de 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome não pode possuir mais de 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; }
        public List<Reserva>? Reservas { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
