using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class PолиБд
{
    public string? НаименованиеРоли { get; set; }

    public int Idроли { get; set; }

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();
}
