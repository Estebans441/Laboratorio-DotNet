using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_dotnet.Models.Entities;

[Table("Persona")]
public partial class Persona
{
    [Key]
    public int Cc { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int? Edad { get; set; }

    [InverseProperty("CcPerNavigation")]
    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();

    [InverseProperty("DuenioNavigation")]
    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
}
