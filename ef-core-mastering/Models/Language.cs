using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<LanguagesUser> LanguagesUsers { get; set; } = new List<LanguagesUser>();
}
