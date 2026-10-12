using System;
using System.Collections.Generic;

namespace primer_api.Models;

public partial class Puesto
{
    public int Idpuestos { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
