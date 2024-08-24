using System;
using System.Collections.Generic;

namespace Biblioteca_Metropolis.Models.CRUD;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
}
