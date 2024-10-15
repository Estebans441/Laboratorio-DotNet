using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_dotnet.Models.Entities
{
    public partial class Telefono
    {
        [Key]
        [StringLength(15)]
        public string Num { get; set; } = null!;

        [Required]
        [StringLength(45)]
        public string Oper { get; set; } = null!;

        public int Duenio { get; set; }

        [ForeignKey("Duenio")]
        [InverseProperty("Telefonos")]
        public virtual Persona DuenioNavigation { get; set; } = null!;
    }
}
