using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ТипыМест
{
    public int IdТипаМеста { get; set; }

    public string НазваниеТипа { get; set; } = null!;

    public virtual ICollection<Места> Местаs { get; set; } = new List<Места>();
}
