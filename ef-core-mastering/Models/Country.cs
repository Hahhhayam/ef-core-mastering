using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Flag { get; set; } = null!;

    public ICollection<User> Users { get; set; } = null!;
}
