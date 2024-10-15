using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.ViewModels
{
    public class TelefonoViewModel
    {
        [Required]
        [Display(Name = "Numero Telefonico")]
        [StringLength(15)]
        [Unicode(false)]
        public string Num { get; set; } = null!;

        [Required]
        [Display(Name = "Operador")]
        [StringLength(45)]
        [Unicode(false)]
        public string Oper { get; set; } = null!;

        [Required]
        [Display(Name = "Registrado a")]
        public int Duenio { get; set; }
    }
}
