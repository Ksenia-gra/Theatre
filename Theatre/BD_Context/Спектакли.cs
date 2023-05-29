using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Спектакли
{
    public int IdСпектакля { get; set; }

    public string НазваниеСпектакля { get; set; } = null!;

    public int КодЖанраСпектакля { get; set; }

    public decimal? Бюджет { get; set; }

    public string? Фото { get; set; }

    public virtual ЖанрыПостановок КодЖанраСпектакляNavigation { get; set; } = null!;

    public virtual ICollection<Расписание> Расписаниеs { get; set; } = new List<Расписание>();

    public virtual ICollection<Абонементы> КодАбонементаs { get; set; } = new List<Абонементы>();

    public virtual ICollection<Инвентарь> КодИнвентаряs { get; set; } = new List<Инвентарь>();

    public virtual ICollection<Костюмы> КодКостюмаs { get; set; } = new List<Костюмы>();

    public virtual ICollection<Роли> КодРолиs { get; set; } = new List<Роли>();

    public virtual ICollection<Сотрудники> КодСотрудникаs { get; set; } = new List<Сотрудники>();
}
