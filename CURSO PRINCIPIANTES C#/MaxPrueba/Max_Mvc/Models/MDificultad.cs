using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Max_Mvc.Models;

public partial class MDificultad
{
    public MDificultad()
    {
        FEjercicio = new HashSet<FEjercicio>();
    }
    public int Id { get; set; }

	[Required(ErrorMessage = "La descripción es obligatoria")]
	public string? Descripcion { get; set; }

    public virtual ICollection<FEjercicio> FEjercicio { get; set; } 
}
