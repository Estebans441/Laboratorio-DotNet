using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.ViewModels
{
    public class ProfesionViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(90)]
        [Unicode(false)]
        public string Nom { get; set; } = null!;
        [Required]
        [StringLength(256)]
        [Unicode(false)]
        public string? Des { get; set; }
    }
}
