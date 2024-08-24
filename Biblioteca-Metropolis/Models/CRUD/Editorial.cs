using System;
using System.Collections.Generic;

namespace Biblioteca_Metropolis.Models.CRUD;

public partial class Editorial
{
    public int IdEdit { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
