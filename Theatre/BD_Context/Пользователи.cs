using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Пользователи
{
    public int Idпользователя { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? Почта { get; set; }

    public string? Соль { get; set; }

    public int? КодРоли { get; set; }

    public virtual ICollection<Билеты> Билетыs { get; set; } = new List<Билеты>();

    public virtual PолиБд? КодРолиNavigation { get; set; }
}
