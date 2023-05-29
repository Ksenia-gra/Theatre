using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Звания
{
    public int IdЗвания { get; set; }

    public string НаименованиеЗвания { get; set; } = null!;

    public string? УсловияПолучения { get; set; }

    public virtual ICollection<ВыданныеЗвания> ВыданныеЗванияs { get; set; } = new List<ВыданныеЗвания>();
}
