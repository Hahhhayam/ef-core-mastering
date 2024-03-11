using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Run> Runs { get; set; } = null!;
}
