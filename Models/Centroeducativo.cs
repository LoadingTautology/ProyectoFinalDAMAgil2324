using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Centroeducativo
{
    public int IdCentro { get; set; }

    public string NombreCentro { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
