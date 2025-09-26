using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AgenciaTurismo.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(120)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required, MaxLength(14)]
        public string CPF { get; set; } = string.Empty;
    }
}
