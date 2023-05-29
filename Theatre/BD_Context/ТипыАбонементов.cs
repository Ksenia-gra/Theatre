using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ТипыАбонементов
{
    public int IdТипа { get; set; }

    public string? НазваниеТипа { get; set; }

    public string? ОписаниеТипа { get; set; }

    public virtual ICollection<Абонементы> Абонементыs { get; set; } = new List<Абонементы>();
}
