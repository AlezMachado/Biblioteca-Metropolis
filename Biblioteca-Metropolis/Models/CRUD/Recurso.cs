using System;
using System.Collections.Generic;

namespace Biblioteca_Metropolis.Models.CRUD;

public partial class Recurso
{
    public int IdRec { get; set; }

    public string Titulo { get; set; } = null!;

    public DateOnly Annopublic { get; set; }

    public int IdEdit { get; set; }

    public string Edicion { get; set; } = null!;

    public int IdPais { get; set; }

    public string Palabrasbusqueda { get; set; } = null!;

    public virtual Editorial IdEditNavigation { get; set; } = null!;

    public virtual Pai IdPaisNavigation { get; set; } = null!;
}
