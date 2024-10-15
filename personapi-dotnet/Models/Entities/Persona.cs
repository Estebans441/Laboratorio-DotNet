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
        public int Cc { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(45)]
        public string Apellido { get; set; } = null!;

        [Required]
        [StringLength(1)]
        public string Genero { get; set; } = null!;

        public int? Edad { get; set; }

        [InverseProperty("DuenioNavigation")]
        public virtual ICollection<Telefono> Telefonos { get; set; }

        [InverseProperty("CcPerNavigation")]
        public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
