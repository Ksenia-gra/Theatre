using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Абонементы
{
    public int IdАбонемента { get; set; }

    public int? КодТипа { get; set; }

    public decimal? Стоимость { get; set; }

    public int? КодКлиента { get; set; }

    public DateOnly? ДатаНачала { get; set; }

    public DateOnly? ДатаОкончания { get; set; }

    public virtual Клиенты? КодКлиентаNavigation { get; set; }

    public virtual ТипыАбонементов? КодТипаNavigation { get; set; }

    public virtual ICollection<Спектакли> КодСпектакляs { get; set; } = new List<Спектакли>();
}
