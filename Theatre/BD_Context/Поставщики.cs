using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Поставщики
{
    public int IdПоставщика { get; set; }

    public string ИмяПоставщика { get; set; } = null!;

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public virtual ICollection<Договоры> Договорыs { get; set; } = new List<Договоры>();
}
