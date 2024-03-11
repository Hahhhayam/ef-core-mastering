using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Team
{
    public int Id { get; set; }

    public int RunId { get; set; }

    public int SpeedrunnerId { get; set; }

    public virtual Run Run { get; set; } = null!;

    public virtual User Speedrunner { get; set; } = null!;
}
