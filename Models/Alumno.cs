using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public DateOnly FechaDeNacimiento { get; set; }

    public virtual ICollection<Asistenciaalumno> Asistenciaalumnos { get; set; } = new List<Asistenciaalumno>();

    public virtual ICollection<Dudasalumnoprofesor> Dudasalumnoprofesors { get; set; } = new List<Dudasalumnoprofesor>();

    public virtual Usuario IdAlumnoNavigation { get; set; } = null!;

    public virtual ICollection<Matriculasalumno> Matriculasalumnos { get; set; } = new List<Matriculasalumno>();
}
