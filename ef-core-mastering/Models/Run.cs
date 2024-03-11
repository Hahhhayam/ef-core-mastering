using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Run
{
    public int Id { get; set; }

    public int GamePlatformId { get; set; }

    public int CategoryId { get; set; }

    public string VideoUrl { get; set; } = null!;

    public TimeOnly Result { get; set; }

    public DateTime Uploaded { get; set; }

    public virtual ICollection<Approve> Approves { get; set; } = new List<Approve>();

    public virtual Category Category { get; set; } = null!;

    public virtual GamesPlatform GamePlatform { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
