using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace personapi_dotnet.Models.Entities;

[PrimaryKey("IdProf", "CcPer")]
[Table("Estudio")
    ]
public partial class Estudio
{
    [Key]
    [Display(Name = "Profesion")]
    public int IdProf { get; set; }

    [Display(Name = "Persona")]
    [Key]
    public int CcPer { get; set; }

    public DateOnly? Fecha { get; set; }

    [Display(Name = "Universidad")]
    public string? Univer { get; set; }

    [ForeignKey("CcPer")]
    [InverseProperty("Estudios")]
    public virtual Persona CcPerNavigation { get; set; } = null!;

    [ForeignKey("IdProf")]
    [InverseProperty("Estudios")]
    public virtual Profesion IdProfNavigation { get; set; } = null!;
}
