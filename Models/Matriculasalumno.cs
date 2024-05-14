using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Matriculasalumno
{
    public int IdAlumno { get; set; }

    public int IdAsignatura { get; set; }

    public int IdCiclo { get; set; }

    public float Eva1 { get; set; }

    public float? Eva2 { get; set; }

    public float? Eva3 { get; set; }

    public virtual Asignaturascicloformativo Asignaturascicloformativo { get; set; } = null!;

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;
}
