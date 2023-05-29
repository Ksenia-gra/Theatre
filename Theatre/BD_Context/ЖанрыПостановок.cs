using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ЖанрыПостановок
{
    public int IdЖанра { get; set; }

    public string НаименованиеЖанра { get; set; } = null!;

    public string? ОписаниеЖанра { get; set; }

    public virtual ICollection<Спектакли> Спектаклиs { get; set; } = new List<Спектакли>();
}
