using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Entities;

[Table("Profesion")]
public partial class Profesion
{
    [Display(Name = "ID Profesion")]
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string Nom { get; set; } = null!;

    [Display(Name = "Descripcion")]
    public string? Des { get; set; }
    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();
}
