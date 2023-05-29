using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Расписание
{
    public int IdРасписания { get; set; }

    public int КодСпектакля { get; set; }

    public DateOnly ДатаНачала { get; set; }

    public TimeOnly ВремяНачала { get; set; }

    public virtual ICollection<Билеты> Билетыs { get; set; } = new List<Билеты>();

    public virtual Спектакли КодСпектакляNavigation { get; set; } = null!;
}
