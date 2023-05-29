using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Должности
{
    public int IdДолжности { get; set; }

    public string НаименованиеДолжности { get; set; } = null!;

    public string? Требования { get; set; }

    public string? Обязанности { get; set; }

    public decimal Зарплата { get; set; }

    public virtual ICollection<Сотрудники> Сотрудникиs { get; set; } = new List<Сотрудники>();
}
