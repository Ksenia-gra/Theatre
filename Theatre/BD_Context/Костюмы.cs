using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Костюмы
{
    public int IdКостюма { get; set; }

    public string НазваниеКостюма { get; set; } = null!;

    public int КодДоговора { get; set; }

    public DateOnly? ДатаНачалаИспользования { get; set; }

    public DateOnly? ДатаСписания { get; set; }

    public decimal? Стоимость { get; set; }

    public int? КодТипа { get; set; }

    public virtual Договоры КодДоговораNavigation { get; set; } = null!;

    public virtual ТипКостюма? КодТипаNavigation { get; set; }

    public virtual ICollection<Спектакли> КодСпектакляs { get; set; } = new List<Спектакли>();
}
