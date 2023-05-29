using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ТипКостюма
{
    public int IdТипа { get; set; }

    public string? НазваниеТипа { get; set; }

    public virtual ICollection<Костюмы> Костюмыs { get; set; } = new List<Костюмы>();
}
