using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_dotnet.Models.Entities
{
    public partial class Telefono
    {
        [Key]
        [StringLength(15)]
        [DisplayName("Numero Telefonico")]
        public string Num { get; set; } = null!;

        [Required]
        [StringLength(45)]
        [DisplayName("Operador")]
        public string Oper { get; set; } = null!;

        [DisplayName("Registrado a")]
        public int Duenio { get; set; }

        [ForeignKey("Duenio")]
        [InverseProperty("Telefonos")]
        public virtual Persona DuenioNavigation { get; set; } = null!;
    }
}
