using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.ViewModels
{
    public class PersonaViewModel
    {
        [Required]
        [Display(Name = "Cedula")]
        public int Cc { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(45)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = null!;

        [Required]
        [StringLength(1)]
        [Display(Name ="Genero")]
        public string Genero { get; set; } = null!;

        [Required]
        [Display(Name = "Edad")]
        public int? Edad { get; set; }
    }
}
