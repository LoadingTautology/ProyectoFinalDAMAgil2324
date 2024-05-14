using System;
using System.Collections.Generic;

namespace ProyectoFinalDAMAgil2324.Models;

public partial class Correoelectronico
{
    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
