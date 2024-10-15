using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_dotnet.Models.Entities;

[Table("Telefono")]
public partial class Telefono
{
    [Key]
    public string Num { get; set; } = null!;

    public string Oper { get; set; } = null!;

    public int Duenio { get; set; }

    [ForeignKey("Duenio")]
    [InverseProperty("Telefonos")]
    public virtual Persona DuenioNavigation { get; set; } = null!;
}
