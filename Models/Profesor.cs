using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string Especialidad { get; set; } = null!;

    public virtual ICollection<Dudasalumnoprofesor> Dudasalumnoprofesors { get; set; } = new List<Dudasalumnoprofesor>();

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;

    public virtual ICollection<Asignaturascicloformativo> Asignaturascicloformativos { get; set; } = new List<Asignaturascicloformativo>();
}
