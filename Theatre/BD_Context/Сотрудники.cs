using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Сотрудники
{
    public int IdСотрудника { get; set; }

    public int КодДолжности { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? СерияПаспорта { get; set; }

    public string? НомерПаспорта { get; set; }

    public string? КемВыдан { get; set; }

    public virtual ICollection<Актеры> Актерыs { get; set; } = new List<Актеры>();

    public virtual ICollection<Дублеры> Дублерыs { get; set; } = new List<Дублеры>();

    public virtual Должности КодДолжностиNavigation { get; set; } = null!;

    public virtual ICollection<Спектакли> КодСпектакляs { get; set; } = new List<Спектакли>();
}
