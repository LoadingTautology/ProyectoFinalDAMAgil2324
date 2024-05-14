using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Examenasignatura
{
    public int IdAsignatura { get; set; }

    public int IdExamen { get; set; }

    public string Descripcion { get; set; } = null!;

    public int NumEvaluacion { get; set; }

    public TimeOnly Tiempo { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
}
