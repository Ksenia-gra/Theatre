using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Актеры
{
    public int IdАктера { get; set; }

    public int КодСотрудника { get; set; }

    public char Пол { get; set; }

    public string? ВнешниеОсобенности { get; set; }

    public string? Фото { get; set; }

    public virtual ICollection<ВыданныеЗвания> ВыданныеЗванияs { get; set; } = new List<ВыданныеЗвания>();

    public virtual Сотрудники КодСотрудникаNavigation { get; set; } = null!;

    public virtual Пол ПолNavigation { get; set; } = null!;

    public virtual ICollection<РолиАктеров> РолиАктеровs { get; set; } = new List<РолиАктеров>();

    public virtual ICollection<Дублеры> КодДублераs { get; set; } = new List<Дублеры>();
}
