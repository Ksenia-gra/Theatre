using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Билеты
{
    public int IdБилета { get; set; }

    public int КодМеста { get; set; }

    public int КодРасписания { get; set; }

    public decimal Стоимость { get; set; }

    public bool Продан { get; set; }

    public int? КодПользователя { get; set; }

    public virtual Места КодМестаNavigation { get; set; } = null!;

    public virtual Пользователи? КодПользователяNavigation { get; set; }

    public virtual Расписание КодРасписанияNavigation { get; set; } = null!;
}
