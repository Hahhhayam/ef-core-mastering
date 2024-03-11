using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public GamesPlatform? GamesPlatform { get; set; }
}
