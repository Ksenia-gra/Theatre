using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Места
{
    public int IdМеста { get; set; }

    public short НомерМеста { get; set; }

    public short Ряд { get; set; }

    public int КодТипаМеста { get; set; }

    public virtual ICollection<Билеты> Билетыs { get; set; } = new List<Билеты>();

    public virtual ТипыМест КодТипаМестаNavigation { get; set; } = null!;
}
