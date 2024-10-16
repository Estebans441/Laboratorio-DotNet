using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.ViewModels
{
    public class EstudioViewModel
    {
        [Required]
        [Display(Name = "Profesion")]
        public int IdProf { get; set; }
        
        [Required]
        [Display(Name = "Persona")]
        public int CcPer { get; set; }
        
        [Required]
        [Display(Name = "Fecha")]
        public DateOnly? Fecha { get; set; }

        [Required]
        [Display(Name = "Universidad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Univer { get; set; }
    }
}
