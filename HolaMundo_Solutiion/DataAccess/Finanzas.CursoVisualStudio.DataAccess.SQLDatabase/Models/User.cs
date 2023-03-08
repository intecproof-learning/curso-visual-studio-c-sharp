using System;
using System.Collections.Generic;

namespace Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

public partial class User
{
    public int Id { get; set; }

    public string NickName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
