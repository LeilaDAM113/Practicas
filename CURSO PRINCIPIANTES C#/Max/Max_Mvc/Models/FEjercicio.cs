using System;
using System.Collections.Generic;

namespace Max_Mvc.Models;

public partial class FEjercicio
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Explicacion { get; set; }

    public int? Dificultad { get; set; }

    public int? TipoCurso { get; set; }

    public virtual MDificultad? DificultadNavigation { get; set; }

    public virtual MTipoCurso? TipoCursoNavigation { get; set; }
}
