using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MinLength(3, ErrorMessage = "O título não pode possuir menos de 3 caracteres.")]
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public List<Reserva>? Reservas { get; set; }
    }
}
