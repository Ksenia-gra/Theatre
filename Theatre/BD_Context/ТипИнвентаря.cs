using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ТипИнвентаря
{
    public int IdТипа { get; set; }

    public string? НаименованиеТипа { get; set; }

    public string? ОписаниеТипа { get; set; }

    public virtual ICollection<Инвентарь> Инвентарьs { get; set; } = new List<Инвентарь>();
    public override string ToString()
    {
        return НаименованиеТипа;
    }
}
