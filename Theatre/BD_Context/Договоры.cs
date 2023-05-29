using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Договоры
{
    public int IdДоговора { get; set; }

    public int КодПоставщика { get; set; }

    public string? ДопУсловияДоговора { get; set; }

    public DateOnly? ДатаЗаключенияДоговора { get; set; }

    public virtual Поставщики КодПоставщикаNavigation { get; set; } = null!;

    public virtual ICollection<Костюмы> Костюмыs { get; set; } = new List<Костюмы>();
}
