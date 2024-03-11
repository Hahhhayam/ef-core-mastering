using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Platform
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GamesPlatform> GamesPlatforms { get; set; } = new List<GamesPlatform>();
}
