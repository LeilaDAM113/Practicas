using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Max_Mvc.Models;

public partial class FEjercicio
{
    public int Id { get; set; }

	[Required(ErrorMessage = "El título es obligatorio")]
	public string Titulo { get; set; } = string.Empty;

	[Required(ErrorMessage = "La explicación es obligatoria")]
	public string Explicacion { get; set; } = string.Empty;

	[Required(ErrorMessage = "Debe seleccionar una dificultad")]
	[ForeignKey("DificultadNavigation")]
	public int Dificultad { get; set; }

	[Required(ErrorMessage = "Debe seleccionar un tipo de curso")]
	[ForeignKey("TipoCursoNavigation")]
	public int TipoCurso { get; set; }

	public virtual MDificultad? DificultadNavigation { get; set; }

    public virtual MTipoCurso? TipoCursoNavigation { get; set; }
}
