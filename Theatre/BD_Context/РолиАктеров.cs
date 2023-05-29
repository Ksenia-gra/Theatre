using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class РолиАктеров
{
    public int КодРоли { get; set; }

    public int КодАктера { get; set; }

    public DateOnly? ДатаНазначенияНаРоль { get; set; }

    public DateOnly? ДатаСнятияСРоли { get; set; }

    public virtual Актеры КодАктераNavigation { get; set; } = null!;

    public virtual Роли КодРолиNavigation { get; set; } = null!;
}
