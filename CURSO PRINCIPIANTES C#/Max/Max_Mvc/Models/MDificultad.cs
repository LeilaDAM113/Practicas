using System;
using System.Collections.Generic;

namespace Max_Mvc.Models;

public partial class MDificultad
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<FEjercicio> FEjercicio { get; set; } = new List<FEjercicio>();
}
