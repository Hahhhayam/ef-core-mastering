using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class GamesPlatform
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int PlatformId { get; set; }

    public Game Game { get; set; } = null!;
    public Platform Platform { get; set; } = null!;
    public ICollection<Run> Runs { get; set; } = null!;
}
