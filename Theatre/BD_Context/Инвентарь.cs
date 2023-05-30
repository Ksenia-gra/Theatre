using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Theatre.BD_Context;

public partial class Инвентарь
{
    [Description("Код")]
    [ReadOnly(true)]
    public int IdИнвентаря { get; set; }

    [Description("Наименование")]
    public string НазваниеИнвентаря { get; set; } = null!;

    [Description("Начало использования")]
    public DateTime? ДатаНачалаИспользования { get; set; }

    [Description("Срок использования")]
    public int СрокИспользования { get; set; }

    [Description("Дата списания")]
    public DateTime? ДатаСписания { get; set; }

    [Description("Стоимость")]
    public decimal? Стоимость { get; set; }

    public int? КодТипа { get; set; }

    [Description("Тип")]
    public virtual ТипИнвентаря? КодТипаNavigation { get; set; }

    public virtual ICollection<Спектакли> КодСпектакляs { get; set; } = new List<Спектакли>();  
    
    
}
