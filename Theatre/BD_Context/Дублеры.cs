using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Дублеры
{
    public int IdДублера { get; set; }

    public int? КодСотрудника { get; set; }

    public char? Пол { get; set; }

    public string? ВнешниеОсобенности { get; set; }

    public virtual Сотрудники? КодСотрудникаNavigation { get; set; }

    public virtual Пол? ПолNavigation { get; set; }

    public virtual ICollection<Актеры> КодАктераs { get; set; } = new List<Актеры>();
}
