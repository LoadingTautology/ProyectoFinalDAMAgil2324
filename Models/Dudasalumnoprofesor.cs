using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Dudasalumnoprofesor
{
    public int IdAlumno { get; set; }

    public int IdProfesor { get; set; }

    public int IdAsignatura { get; set; }

    public int IdCiclo { get; set; }

    public TimeOnly Fecha { get; set; }

    public bool? Atender { get; set; }

    public virtual Asignaturascicloformativo Asignaturascicloformativo { get; set; } = null!;

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;
}
