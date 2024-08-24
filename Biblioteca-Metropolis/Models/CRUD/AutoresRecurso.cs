using System;
using System.Collections.Generic;

namespace Biblioteca_Metropolis.Models.CRUD;

public partial class AutoresRecurso
{
    public int IdRec { get; set; }

    public int IdAutor { get; set; }

    public string EsPrincipal { get; set; } = null!;

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual Recurso IdRecNavigation { get; set; } = null!;
}
