using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class ВыданныеЗвания
{
    public int IdВыданногоЗвания { get; set; }

    public DateOnly? ДатаВыдачи { get; set; }

    public int? КодАктера { get; set; }

    public int? КодЗвания { get; set; }

    public virtual Актеры? КодАктераNavigation { get; set; }

    public virtual Звания? КодЗванияNavigation { get; set; }
}
