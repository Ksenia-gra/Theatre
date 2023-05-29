using System;
using System.Collections.Generic;

namespace Theatre.BD_Context;

public partial class Sale
{
    public DateOnly? ДатаПродаж { get; set; }

    public decimal? СуммаПродаж { get; set; }
}
