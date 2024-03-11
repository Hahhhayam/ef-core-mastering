using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Approve> Approves { get; set; } = new List<Approve>();
}
