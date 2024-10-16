using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_dotnet.Models.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Estudios = new HashSet<Estudio>();
            Telefonos = new HashSet<Telefono>();
        }

        [Key]
        [Display(Name = "Cedula de Ciudadania")]
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
        [Display(Name = "Genero")]
        public string Genero { get; set; } = null!;

        [Display(Name = "Edad")]
        public int? Edad { get; set; }

        [InverseProperty("DuenioNavigation")]
        public virtual ICollection<Telefono> Telefonos { get; set; }

        [InverseProperty("CcPerNavigation")]
        public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
