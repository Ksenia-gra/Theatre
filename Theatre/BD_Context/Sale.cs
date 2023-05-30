using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.BD_Context;

public partial class Sale
{
    [Key]
    public DateOnly? ДатаПродаж { get; set; }

    public decimal? СуммаПродаж { get; set; }
}
