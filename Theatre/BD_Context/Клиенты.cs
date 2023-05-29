using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Клиенты
{
    public int IdКлиента { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Отчество { get; set; }

    public int? СерияПаспорта { get; set; }

    public int? НомерПаспорта { get; set; }

    public string? Телефон { get; set; }

    public string? Адрес { get; set; }

    public virtual ICollection<Абонементы> Абонементыs { get; set; } = new List<Абонементы>();
}
