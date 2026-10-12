using System;
using System.Collections.Generic;

namespace primer_api.Models;

public partial class Empleado
{
    public int Idempleados { get; set; }

    public int Idpuesto { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public virtual Puesto IdpuestoNavigation { get; set; } = null!;
}
