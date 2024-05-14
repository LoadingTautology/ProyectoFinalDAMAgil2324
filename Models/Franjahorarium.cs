using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Franjahorarium
{
    public TimeOnly HoraMinInicio { get; set; }

    public TimeOnly HoraMinFinal { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
