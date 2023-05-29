using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Пол
{
    public int IdПол { get; set; }

    public char? КодПола { get; set; }

    public virtual ICollection<Актеры> Актерыs { get; set; } = new List<Актеры>();

    public virtual ICollection<Дублеры> Дублерыs { get; set; } = new List<Дублеры>();
}
