using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Administrador
{
    public int IdAdministrador { get; set; }

    public string Dni { get; set; } = null!;

    public virtual Usuario IdAdministradorNavigation { get; set; } = null!;
}
