using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico? PacoteTuristico { get; set; }

        [Required(ErrorMessage = "Informe a data da reserva.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; }
    }
}
