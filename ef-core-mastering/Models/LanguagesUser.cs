using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class LanguagesUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
