using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Max_Mvc.Models;

public partial class MTipoCurso
{
	public MTipoCurso()
	{
		FEjercicio = new HashSet<FEjercicio>();
	}
	public int Id { get; set; }

	[Required(ErrorMessage = "La descripcion es obligatoria")]
	public string? Descripcion { get; set; }

	public virtual ICollection<FEjercicio> FEjercicio { get; set; }
}
