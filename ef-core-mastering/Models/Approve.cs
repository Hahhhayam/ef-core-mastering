using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Approve
{
    public int Id { get; set; }

    public int RunId { get; set; }

    public int AdminId { get; set; }

    public int RoleId { get; set; }

    public int StatusId { get; set; }

    public virtual User Admin { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual Run Run { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
