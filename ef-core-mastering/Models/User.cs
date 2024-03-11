using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<Approve> Approves { get; set; } = new List<Approve>();

    public virtual ContactsUser? ContactsUser { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual LanguagesUser? LanguagesUser { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
