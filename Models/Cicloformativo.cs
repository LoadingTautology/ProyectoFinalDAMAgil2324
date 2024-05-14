using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Cicloformativo
{
    public int IdCiclo { get; set; }

    public string NombreCiclo { get; set; } = null!;

    public virtual ICollection<Asignaturascicloformativo> Asignaturascicloformativos { get; set; } = new List<Asignaturascicloformativo>();
}
