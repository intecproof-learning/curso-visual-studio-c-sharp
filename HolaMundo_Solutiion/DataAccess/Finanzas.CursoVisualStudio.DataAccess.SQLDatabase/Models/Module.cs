using System;
using System.Collections.Generic;

namespace Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<UserModuleRel> UserModuleRels { get; } = new List<UserModuleRel>();
}
