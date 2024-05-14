using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Asistenciaalumno
{
    public int IdAlumno { get; set; }

    public int IdAsignatura { get; set; }

    public int IdCiclo { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Asignaturascicloformativo Asignaturascicloformativo { get; set; } = null!;

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;
}
