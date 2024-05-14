using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string NombreAsignatura { get; set; } = null!;

    public int Curso { get; set; }

    public virtual ICollection<Asignaturascicloformativo> Asignaturascicloformativos { get; set; } = new List<Asignaturascicloformativo>();

    public virtual ICollection<Examenasignatura> Examenasignaturas { get; set; } = new List<Examenasignatura>();
}
