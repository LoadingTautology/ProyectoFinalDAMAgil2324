using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Asignaturascicloformativo
{
    public int IdAsignatura { get; set; }

    public int IdCiclo { get; set; }

    public virtual ICollection<Asistenciaalumno> Asistenciaalumnos { get; set; } = new List<Asistenciaalumno>();

    public virtual ICollection<Dudasalumnoprofesor> Dudasalumnoprofesors { get; set; } = new List<Dudasalumnoprofesor>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Cicloformativo IdCicloNavigation { get; set; } = null!;

    public virtual ICollection<Matriculasalumno> Matriculasalumnos { get; set; } = new List<Matriculasalumno>();

    public virtual ICollection<Profesor> IdProfesors { get; set; } = new List<Profesor>();
}
