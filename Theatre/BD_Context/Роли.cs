using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Роли
{
    public int IdРоли { get; set; }

    public string НазваниеРоли { get; set; } = null!;

    public string? ДопИнформация { get; set; }

    public virtual ICollection<РолиАктеров> РолиАктеровs { get; set; } = new List<РолиАктеров>();

    public virtual ICollection<Спектакли> КодСпектакляs { get; set; } = new List<Спектакли>();
}
