using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Entities;

[Table("Profesion")]
public partial class Profesion
{
    [Key]
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Des { get; set; }

    [InverseProperty("IdProfNavigation")]
    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();
}
