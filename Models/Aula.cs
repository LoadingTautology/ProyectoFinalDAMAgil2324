using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public string NombreAula { get; set; } = null!;

    public int AforoMax { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
