using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidosUsuario { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Administrador? Administrador { get; set; }

    public virtual Alumno? Alumno { get; set; }

    public virtual Correoelectronico EmailNavigation { get; set; } = null!;

    public virtual Profesor? Profesor { get; set; }

    public virtual ICollection<Centroeducativo> IdCentros { get; set; } = new List<Centroeducativo>();
}
