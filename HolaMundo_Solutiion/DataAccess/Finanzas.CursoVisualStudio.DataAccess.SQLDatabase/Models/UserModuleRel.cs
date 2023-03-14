using System;
using System.Collections.Generic;

namespace Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

public partial class UserModuleRel
{
    public int IdUser { get; set; }

    public int IdModule { get; set; }

    public bool IsActive { get; set; }

    public virtual Module IdModuleNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
